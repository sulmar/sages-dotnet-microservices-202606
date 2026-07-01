using ShoppingCart.Application.Features.AddProductToCart;
using ShoppingCart.Application.Features.Checkout;

namespace ShoppingCart.Api.Features.Checkout;

public static class CheckountEndpoint
{
    public static IEndpointRouteBuilder MapCheckountEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/cart/checkout", async (CheckoutHandler handler) => await handler.HandleAsync());

        return endpoints;
    }
}
