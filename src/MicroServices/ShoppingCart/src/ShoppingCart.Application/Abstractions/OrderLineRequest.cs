namespace ShoppingCart.Application.Abstractions;

public record OrderLineRequest(int ProductId, int Quantity);
