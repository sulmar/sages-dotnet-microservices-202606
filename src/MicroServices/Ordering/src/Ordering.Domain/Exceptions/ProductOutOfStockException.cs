namespace Ordering.Domain.Exceptions;

public sealed class ProductOutOfStockException(int productId) : Exception($"Product {productId} is out of stock.")
{
    public int ProductId { get; } = productId;
}
