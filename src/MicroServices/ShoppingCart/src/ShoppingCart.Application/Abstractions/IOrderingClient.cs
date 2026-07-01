namespace ShoppingCart.Application.Abstractions;

public interface IOrderingClient
{
    Task CreateOrderAsync(CreateOrderRequest request);
}
