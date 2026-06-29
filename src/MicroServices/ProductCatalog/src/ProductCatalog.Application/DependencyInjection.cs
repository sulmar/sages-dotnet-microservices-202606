using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Application.Features.GetProducts;

namespace ProductCatalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<GetProductsHandler>();

        return services;
    }
}
