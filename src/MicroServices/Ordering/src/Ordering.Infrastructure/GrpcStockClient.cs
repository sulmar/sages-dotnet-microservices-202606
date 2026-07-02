using Ordering.Application.Abstractions;

namespace Ordering.Infrastructure;

// {csharp_namespace}.{service}.{service}Client
public class GrpcStockClient(Stock.GrpcService.StockService.StockServiceClient client) : IStockClient
{
    public async Task<bool> CheckAvailabilityAsync(int productId, int quantity)
    {
        var request = new Stock.GrpcService.CheckAvailabilityRequest
        {
            ProductId = productId,
            Quantity = quantity
        };

       var response = await client.CheckAvailabilityAsync(request);

        return response.IsAvailable;
    }

    public async Task<bool> ReserveProductAsync(int productId, int quantity)
    {
        var request = new Stock.GrpcService.ReserveProductRequest
        {
            ProductId = productId,
            Quantity = quantity
        };
        var response = await client.ReserveProductsAsync(request);

        return response.Success;
    }
}
