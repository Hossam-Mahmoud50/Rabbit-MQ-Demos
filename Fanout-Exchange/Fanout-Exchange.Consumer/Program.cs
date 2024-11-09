using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

Console.WriteLine("Waiting for message");

ConsumeMessage("qu-fanout1");
ConsumeMessage("qu-fanout2");
ConsumeMessage("qu-fanout3");
ConsumeMessage("qu-fanout4");
ConsumeMessage("qu-fanout5");
Console.WriteLine("press [Enter] to exit.");
Console.ReadLine();

void ConsumeMessage(string queueName)
{
    var consumer = new AsyncEventingBasicConsumer(channel);
    consumer.ReceivedAsync += async (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        #region Logic to process the Message

        Console.WriteLine($"Received message: {message}");

        #endregion
    };

    channel.BasicConsumeAsync(queueName, false, consumer);
}