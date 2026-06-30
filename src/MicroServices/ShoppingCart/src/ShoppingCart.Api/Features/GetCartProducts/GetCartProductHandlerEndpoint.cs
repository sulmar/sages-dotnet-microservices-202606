using ShoppingCart.Application.Features.GetCartProducts;

namespace ShoppingCart.Api.Features.GetCartProducts;

public static class GetCartProductHandlerEndpoint
{
    public static IEndpointRouteBuilder MapGetCartProductsHandlerEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/cart", async (GetCartProductHandler handler) => await handler.HandleAsync());

        return endpoints;
    }
}
