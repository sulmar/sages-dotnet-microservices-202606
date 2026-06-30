namespace ShoppingCart.Application.Abstractions;

public interface ICartRepository
{
    Task IncrementQuantityAsync(string cartId, int productId, int quantity);
}
