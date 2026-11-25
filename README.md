# Rabbit-MQ-Demos

Producer and consumer console apps in .NET 8 that show RabbitMQ exchange types, using `RabbitMQ.Client` 7.0.0. Each exchange folder also has a short explanation in Arabic.

## Demos

| Folder | Exchange type | Projects |
| --- | --- | --- |
| `Direct-Exchnage` | Direct | `DirectExchange.Producer`, `DirectExchange.Consumer` |
| `Fanout-Exchange` | Fanout (`amq.fanout`) | `Fanout-Exchange.Producer`, `Fanout-Exchange.Consumer` |
| `Topic-Exchange` | Topic (`amq.topic`) | `Topic.Exchange.Producer`, `Topic.Exchange.Consumer` |
| `Header-Exchange` | Headers (`amq.headers`) | `Header.Exchange.Producer`, `Header.Exchange.Consumer` |

## Run

You need the .NET 8 SDK and a RabbitMQ server on `localhost` (default port). All demos connect to `localhost`.

The Fanout, Topic and Headers consumers read queues that already exist (`qu-fanout1` to `qu-fanout5`, `health1` to `health3`, `header1` and `header2`). The code does not create or bind them, so create and bind them in RabbitMQ first, for example in the management UI.

```
dotnet run --project Topic-Exchange/Topic.Exchange.Consumer
dotnet run --project Topic-Exchange/Topic.Exchange.Producer
```
