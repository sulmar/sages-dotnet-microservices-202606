using ShoppingCart.Api.Features.AddProductToCart;
using ShoppingCart.Api.Features.Checkout;

namespace ShoppingCart.Api.Features.GetCartProducts;

public static class HandlerEndpoints
{
    public static IEndpointRouteBuilder MapHandlerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAddProductToCartEndpoint();
        app.MapGetCartProductsHandlerEndpoint();
        app.MapCheckountEndpoint();

        return app;
    }
}