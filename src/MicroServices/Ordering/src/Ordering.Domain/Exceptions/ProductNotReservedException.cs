namespace Ordering.Domain.Exceptions;

public sealed class ProductNotReservedException(int productId) : Exception($"Product {productId} not reserved.")
{
    public int ProductId { get; } = productId;
}
