using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Features.AddProductToCart;
using ShoppingCart.Application.Features.GetCartProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<AddProductToCartHandler>();
        services.AddScoped<GetCartProductHandler>();

        return services;
    }
}
