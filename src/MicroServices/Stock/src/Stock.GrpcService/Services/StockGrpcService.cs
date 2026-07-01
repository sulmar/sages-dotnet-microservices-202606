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
        var response = new CheckAvailabilityResponse
        {
            IsAvailable = true,
            Status = StockStatus.InStock
        };

        return Task.FromResult(response);

        //if (stock.ContainsKey(request.ProductId) && stock[request.ProductId] >= request.Quantity)
        //{
        //    var response = new CheckAvailabilityResponse
        //    {
        //        IsAvailable = true,
        //        Status = StockStatus.InStock
        //    };

        //    return Task.FromResult(response);
        //}

        //else
        //{
        //    var response = new CheckAvailabilityResponse
        //    {
        //        IsAvailable = false,
        //        Status = StockStatus.OutOfStock
        //    };

        //    return Task.FromResult(response);
        //}
    }

        
}
