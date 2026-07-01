using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Abstractions;

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

        return services;
    }
}
