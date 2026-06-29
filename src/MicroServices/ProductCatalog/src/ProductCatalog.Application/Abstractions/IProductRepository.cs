using ProductCatalog.Domain.Products;

namespace ProductCatalog.Application.Abstractions;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllAsync();
}
