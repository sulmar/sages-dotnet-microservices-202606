using ProductCatalog.Application.Features.GetProducts;

namespace ProductCatalog.Api.Features.GetProducts;

public static class GetProductsEndpoint
{
    public static IEndpointRouteBuilder MapGetProducts(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/products", async (GetProductsHandler handler) => Results.Ok(await handler.HandleAsync()));

        return endpoints;
    }
}
