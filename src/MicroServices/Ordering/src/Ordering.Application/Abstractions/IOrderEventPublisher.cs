using Ordering.Application.Features.CreateOrder;

namespace Ordering.Application.Abstractions;

public interface IOrderEventPublisher
{
    Task PublishOrderPlacedAsync(OrderPlacedEvent @event);
}
