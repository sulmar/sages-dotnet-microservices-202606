using ProductCatalog.Application.Features.GetProducts;

namespace ProductCatalog.Application.SearchProducts;

public class SarchProductsHandler
{
    public async Task<IReadOnlyList<ProductListItemDto>> HandleAsync(SearchProductsRequest request)
    {
        throw new NotImplementedException();
    }
}


public record SearchProductsRequest(string Color, string Group);