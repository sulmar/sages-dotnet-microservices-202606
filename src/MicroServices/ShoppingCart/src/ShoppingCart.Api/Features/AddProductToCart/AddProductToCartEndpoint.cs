using ShoppingCart.Application.Features.AddProductToCart;

namespace ShoppingCart.Api.Features.AddProductToCart;

public static class AddProductToCartEndpoint
{
    public static IEndpointRouteBuilder MapAddProductToCartEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/cart", (AddProductToCartHandler  handler) => Results.Ok());

        return endpoints;
    }
}
