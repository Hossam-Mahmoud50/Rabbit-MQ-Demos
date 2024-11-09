using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
IConnection connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

channel.QueueDeclareAsync(queue: "qu-publish",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);
    
    
string message = "Hello, From Producer";
var body = Encoding.UTF8.GetBytes(message);


await channel.BasicPublishAsync(exchange: "", routingKey: "key-publish",  body: body);

Console.WriteLine($" [x] Sent {message}");