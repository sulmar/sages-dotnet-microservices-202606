using ProductCatalog.Application.Abstractions;

namespace ProductCatalog.Application.Features.GetProducts;

// Primary Constructor (.NET 10)
public class GetProductsHandler(IProductRepository repository)
{
    public async Task<IReadOnlyList<ProductListItemDto>> HandleAsync()
    {
        var products = await repository.GetAllAsync();

        return products.Select(product => new ProductListItemDto(product.Id, product.Name, product.Price, product.DiscountedPrice)).ToList();
    }
}
