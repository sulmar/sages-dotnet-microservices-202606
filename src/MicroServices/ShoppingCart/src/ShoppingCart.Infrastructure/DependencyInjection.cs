using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Infrastructure.Persistance;
using StackExchange.Redis;

namespace ShoppingCart.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnectionString = configuration.GetConnectionString("Redis") ?? "localhost:6379";

        services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConnectionString));
        services.AddSingleton<ICartRepository, RedisCartRepository>();

        services.AddHttpClient("OrderingApi", (sp, client) =>
        {
            client.BaseAddress = new Uri(configuration.GetValue<string>("OrderingApi:BaseUrl") ?? "http://localhost:5000");
        });

        services.AddScoped<IOrderingClient, ApiOrderingClient>();

        return services;
    }
}
