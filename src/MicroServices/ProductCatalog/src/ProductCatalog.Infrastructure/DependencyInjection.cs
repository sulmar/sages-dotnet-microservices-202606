using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Domain.Products;
using ProductCatalog.Infrastructure.Persistance;

namespace ProductCatalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var products = ProductDataSeeder.Seed();
        services.AddSingleton<IDictionary<int, Product>>(products);
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();

        return services;
    }
}
