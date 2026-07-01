using FluentValidation;
using Ordering.Application.Abstractions;
using Ordering.Domain.Exceptions;

namespace Ordering.Application.Features.CreateOrder;

public class CreateOrderHandler(IStockClient stockClient, IValidator<CreateOrderRequest> validator, IOrderEventPublisher publisher)
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

            // TODO: Publish OrderPlaced event
            var @event = new OrderPlacedEvent(
                Guid.NewGuid().ToString(), 
                DateTime.UtcNow,                 
                request.Lines.Select(l => new OrderPlacedLine(l.ProductId, l.Quantity)).ToList());
        
            await publisher.PublishOrderPlacedAsync(@event);
        }
    }
}


