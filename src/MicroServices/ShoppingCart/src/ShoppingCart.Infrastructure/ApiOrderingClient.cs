using ShoppingCart.Application.Abstractions;
using System.Net.Http.Json;

namespace ShoppingCart.Infrastructure;

internal class ApiOrderingClient(IHttpClientFactory factory) : IOrderingClient
{
    public async Task CreateOrderAsync(CreateOrderRequest request)
    {
        var http = factory.CreateClient("OrderingApi");

        using var response = await http.PostAsJsonAsync("api/orders", request);

        if (response.IsSuccessStatusCode is false)
        {
            throw new Exception($"Request failed with status code {response.StatusCode}");
        }
    }
}
