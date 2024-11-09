using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

Console.WriteLine("Waiting for message");

channel.QueueDeclareAsync("qu-publish",
    false,
    false,
    false,
    null);

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    #region Logic to process the Message

    Console.WriteLine($"Received message: {message}");

    #endregion
};

channel.BasicConsumeAsync("qu-publish", false, consumer);
Console.WriteLine("press [Enter] to exit.");
Console.ReadLine();