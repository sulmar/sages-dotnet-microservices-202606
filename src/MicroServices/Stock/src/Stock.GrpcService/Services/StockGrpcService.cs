using Grpc.Core;

namespace Stock.GrpcService.Services;

// {csharp_namespace}.{service}.{service}Base
public class StockGrpcService : Stock.GrpcService.StockService.StockServiceBase
{
    // TODO: Przeniesc do Infrastructure/Repository i zrobic prawdziwe sprawdzanie stanu magazynowego
    private readonly Dictionary<int, int> stock = new()
    {
        { 1, 10 },
        { 2, 5 },
        { 3, 0 },
        { 21, 15 }
    };

    public override Task<CheckAvailabilityResponse> CheckAvailability(CheckAvailabilityRequest request, ServerCallContext context)
    {      
        var isAvailable = stock.TryGetValue(request.ProductId, out var availableQuantity) && availableQuantity >= request.Quantity;

        var response = new CheckAvailabilityResponse
        {
            IsAvailable = isAvailable,
            Status = isAvailable ? StockStatus.InStock : StockStatus.OutOfStock
        };

        return Task.FromResult(response);       
    }

        
}
