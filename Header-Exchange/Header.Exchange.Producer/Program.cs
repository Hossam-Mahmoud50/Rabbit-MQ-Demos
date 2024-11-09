using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
IConnection connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();
var properties = new BasicProperties
{
    Persistent = false
};
Dictionary<string, object> headers = new Dictionary<string, object>();
headers.Add("name", "info");

properties.Headers = headers;
string message = "Hello, From Producer";
var body = Encoding.UTF8.GetBytes(message);

var publicationAddress = new PublicationAddress("HeadersExchange", "amq.headers", string.Empty);
await channel.BasicPublishAsync<BasicProperties>(publicationAddress, basicProperties: properties, body: body);

Console.WriteLine($" [x] Sent {message}");  