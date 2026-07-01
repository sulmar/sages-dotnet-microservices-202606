namespace ShoppingCart.Application.Abstractions;

public record OrderRequest(List<OrderLineRequest> Lines);