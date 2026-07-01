namespace Ordering.Application.Features.CreateOrder;

public record OrderLineRequest(int ProductId, int Quantity);