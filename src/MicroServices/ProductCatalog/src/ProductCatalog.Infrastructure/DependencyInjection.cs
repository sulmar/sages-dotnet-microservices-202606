using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Domain.Products;
using ProductCatalog.Infrastructure.Persistance;
using System.Data.Common;

namespace ProductCatalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        var products = ProductDataSeeder.Seed();
        services.AddSingleton<IDictionary<int, Product>>(products);

        //services.AddSingleton<IProductRepository, InMemoryProductRepository>();

        services.AddScoped<DbConnection>(_ => new SqliteConnection(connectionString));
        services.AddScoped<IProductRepository, SqliteProductRepository>();
        services.AddScoped<DatabaseInitializer>();

        return services;
    }
}
