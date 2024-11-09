using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
IConnection connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

    
string message = "Hello, From Producer";
var body = Encoding.UTF8.GetBytes(message);


await channel.BasicPublishAsync(exchange: "amq.topic", routingKey: "h.y",  body: body);

Console.WriteLine($" [x] Sent {message}");