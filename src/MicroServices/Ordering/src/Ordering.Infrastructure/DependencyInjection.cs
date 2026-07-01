using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Abstractions;
using StackExchange.Redis;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<Stock.GrpcService.StockService.StockServiceClient>(options =>
        {
            options.Address = new Uri(configuration["StockService:BaseUrl"]);
        });

        services.AddScoped<IStockClient, GrpcStockClient>();
        services.AddScoped<IOrderEventPublisher, RedisOrderEventPublisher>();
        services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis") ?? "localhost:6379"));    
        
        return services;
    }
}
