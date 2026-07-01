using Ordering.Application.Abstractions;

namespace Ordering.Application.Features.CreateOrder;

public class CreateOrderHandler(IStockClient stockClient)
{
    public async Task HandleAsync(CreateOrderRequest request)
    {
        foreach (var item in request.Lines)
        {
            var result = await stockClient.CheckAvailabilityAsync(item.ProductId, item.Quantity);

            if (result)
            {
                // Proceed with order creation logic
            }
            else
            {
                // Handle out-of-stock scenario
                throw new InvalidOperationException($"Product {item.ProductId} is out of stock.");
            }
        }                
    }
}
