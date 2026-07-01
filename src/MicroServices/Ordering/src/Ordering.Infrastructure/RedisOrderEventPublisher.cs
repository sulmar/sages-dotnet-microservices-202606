using Ordering.Application.Abstractions;
using Ordering.Application.Features.CreateOrder;
using StackExchange.Redis;

namespace Ordering.Infrastructure;

internal class RedisOrderEventPublisher(IConnectionMultiplexer connection) : IOrderEventPublisher
{
    private const string  StreamName = "orders-stream";
    private const string EventType = "order-placed"; 

    public async Task PublishOrderPlacedAsync(OrderPlacedEvent @event)
    {
        var  db = connection.GetDatabase();

        await db.StreamAddAsync(StreamName,
        [
            new NameValueEntry("orderId", @event.OrderId),
            new NameValueEntry("type", EventType),
            new NameValueEntry("occuredAt", @event.OccuredAt.ToString("o")),
            new NameValueEntry("lines", System.Text.Json.JsonSerializer.Serialize(@event.Lines))
        ]);       
    }
}
