using System.Net.Http.Json;
using System.Net;

namespace BlazorApp.Services;

public class ApiCartService(HttpClient _httpClient) : ICartService
{
    public event Action? CartChanged;

    public async Task AddToCartAsync(int productId, int quantity = 1)
    {
        var request = new { productId, quantity };
        var response = await _httpClient.PostAsJsonAsync("api/cart", request);
        EnsureAuthorized(response);
        response.EnsureSuccessStatusCode();
        CartChanged?.Invoke();
    }

    public async Task RemoveFromCartAsync(int productId)
    {
        var response = await _httpClient.DeleteAsync($"api/cart/{productId}");
        EnsureAuthorized(response);
        response.EnsureSuccessStatusCode();
        CartChanged?.Invoke();
    }

    public async Task<List<Model.CartItem>?> GetCartItemsAsync()
    {
        var response = await _httpClient.GetAsync("api/cart");
        EnsureAuthorized(response);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<Model.CartItem>>();
    }

    public async Task CheckoutAsync()
    {
        var response = await _httpClient.PostAsync("api/cart/checkout", null);
        EnsureAuthorized(response);
        response.EnsureSuccessStatusCode();
        CartChanged?.Invoke();
    }

    private static void EnsureAuthorized(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedApiException();
        }
    }
}
