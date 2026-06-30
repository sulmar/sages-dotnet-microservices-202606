using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Features.AddProductToCart;

namespace ShoppingCart.Api.Features.AddProductToCart;

public static class AddProductToCartEndpoint
{
    public static IEndpointRouteBuilder MapAddProductToCartEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/cart", async (AddProductToCartRequest request, AddProductToCartHandler handler) => await handler.HandleAsync(request));

        return endpoints;
    }
}
