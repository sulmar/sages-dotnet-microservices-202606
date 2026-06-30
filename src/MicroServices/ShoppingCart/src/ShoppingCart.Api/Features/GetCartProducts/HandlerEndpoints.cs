using ShoppingCart.Api.Features.AddProductToCart;

namespace ShoppingCart.Api.Features.GetCartProducts;

public static class HandlerEndpoints
{
    public static IEndpointRouteBuilder MapHandlerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAddProductToCartEndpoint();
        app.MapGetCartProductsHandlerEndpoint();

        return app;
    }
}