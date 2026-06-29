using ProductCatalog.Application.SearchProducts;

namespace ProductCatalog.Api.Features.SearchProducts;

public static class SearchProductsEndpoint
{
    // GET api/products?color=red&group=B
    public static IEndpointRouteBuilder MapSearchProductsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/products", async ([AsParameters] SearchProductsRequest request, SarchProductsHandler handler) => await handler.HandleAsync(request) );

        return endpoints;
    }
}


