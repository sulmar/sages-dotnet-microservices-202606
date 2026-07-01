using Ordering.Application.Abstractions;

namespace Ordering.Application.Features.CreateOrder;

public class CreateOrderHandler(IStockClient stockClient)
{
    public async Task HandleAsync(CreateOrderRequest request)
    {
        foreach (var item in request.Lines)
        {
            bool available = await stockClient.CheckAvailabilityAsync(item.ProductId, item.Quantity);

            if (!available)            
                throw new InvalidOperationException($"Product {item.ProductId} is out of stock.");
            
            // TODO: Save order

            // TODO: Publish OrderCreated event
        }
    }
}
