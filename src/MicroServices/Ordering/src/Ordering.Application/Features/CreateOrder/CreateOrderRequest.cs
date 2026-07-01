namespace Ordering.Application.Features.CreateOrder;

public record CreateOrderRequest(List<OrderLineRequest> Lines);
