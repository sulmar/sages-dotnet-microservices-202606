using Ordering.Application.Abstractions;
using Ordering.Domain.Exceptions;

namespace Ordering.Application.Features.CreateOrder;

public class CreateOrderHandler(IStockClient stockClient)
{
    public async Task HandleAsync(CreateOrderRequest request)
    {
        foreach (var item in request.Lines)
        {
            bool available = await stockClient.CheckAvailabilityAsync(item.ProductId, item.Quantity);

            if (!available)
                throw new ProductOutOfStockException(item.ProductId);

            // TODO: Save order

                // TODO: Publish OrderCreated event
        }
    }
}


