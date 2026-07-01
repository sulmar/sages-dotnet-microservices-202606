using Ordering.Application.Features.CreateOrder;

namespace Ordering.Api.Features.CreateOrder;

public static class CreateOrderEndpoint
{
    public static IEndpointRouteBuilder MapCreateOrderEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/orders", async (CreateOrderRequest request, CreateOrderHandler handler) => handler.HandleAsync());

        return endpoints;
    }
}


public record CreateOrderRequest(List<OrderLineRequest> Lines);

public record OrderLineRequest(string ProductId, int Quantity);