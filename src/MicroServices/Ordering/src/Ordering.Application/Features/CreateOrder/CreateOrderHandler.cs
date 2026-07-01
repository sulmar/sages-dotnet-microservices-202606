using FluentValidation;
using Ordering.Application.Abstractions;
using Ordering.Domain.Exceptions;

namespace Ordering.Application.Features.CreateOrder;

public class CreateOrderHandler(IStockClient stockClient, IValidator<CreateOrderRequest> validator)
{
    public async Task HandleAsync(CreateOrderRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

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


