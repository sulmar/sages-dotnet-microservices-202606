using Ordering.Application.Features.CreateOrder;

namespace Ordering.Api.Features.CreateOrder;

public static class CreateOrderEndpoint
{
    public static IEndpointRouteBuilder MapCreateOrderEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/orders", async (CreateOrderRequest request, CreateOrderHandler handler) => handler.HandleAsync(request));

        return endpoints;
    }
}

