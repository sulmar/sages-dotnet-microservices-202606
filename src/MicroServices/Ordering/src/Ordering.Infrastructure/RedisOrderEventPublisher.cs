using Ordering.Application.Abstractions;
using Ordering.Application.Features.CreateOrder;

namespace Ordering.Infrastructure;

internal class RedisOrderEventPublisher : IOrderEventPublisher
{
    public Task PublishOrderPlacedAsync(OrderPlacedEvent @event)
    {
        throw new NotImplementedException();
    }
}
