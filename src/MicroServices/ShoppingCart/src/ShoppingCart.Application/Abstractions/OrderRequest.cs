namespace ShoppingCart.Application.Abstractions;

public record CreateOrderRequest(List<OrderLineRequest> Lines);