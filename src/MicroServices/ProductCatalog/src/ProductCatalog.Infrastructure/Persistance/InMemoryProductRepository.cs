using ProductCatalog.Application.Abstractions;
using ProductCatalog.Domain.Products;

namespace ProductCatalog.Infrastructure.Persistance;

public class InMemoryProductRepository(IDictionary<int, Product> products) : IProductRepository
{
    public Task<IReadOnlyList<Product>> GetAllAsync()
    {
        var result = products.Values.ToList();

        return Task.FromResult<IReadOnlyList<Product>>(result);
    }
}
