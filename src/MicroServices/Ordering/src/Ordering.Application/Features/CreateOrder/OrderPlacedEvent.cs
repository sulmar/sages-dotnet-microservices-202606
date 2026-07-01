namespace Ordering.Application.Features.CreateOrder;

public record OrderPlacedEvent(string OrderId, DateTime OccuredAt, List<OrderPlacedLine> Lines);

public record OrderPlacedLine(int ProductId, int Quantity);
