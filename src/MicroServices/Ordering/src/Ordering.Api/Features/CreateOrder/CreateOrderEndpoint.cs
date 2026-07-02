using FluentValidation;
using Ordering.Application.Features.CreateOrder;
using Ordering.Domain.Exceptions;

namespace Ordering.Api.Features.CreateOrder;

public static class CreateOrderEndpoint
{
    public static IEndpointRouteBuilder MapCreateOrderEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/orders", async (CreateOrderRequest request, CreateOrderHandler handler) =>
        {
            try
            {
                await handler.HandleAsync(request);

                return Results.Ok();
            }
            catch(ValidationException ex)
            {
                return Results.ValidationProblem(ex.Errors
                    .GroupBy(e=>e.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray())
                    );
            }
            catch (ProductOutOfStockException ex)
            {
                return Results.Problem(
                    type: "https://example.net/problems/product-out-of-stock",
                    title: "Product unavailable",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status409Conflict
                );
            }

            catch (ProductNotReservedException ex)
            {
                return Results.Problem(
                    type: "https://example.net/problems/product-not-reserved",
                    title: "Product not reserved",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status409Conflict
                );
            }

        });


        return endpoints;
    }
}

