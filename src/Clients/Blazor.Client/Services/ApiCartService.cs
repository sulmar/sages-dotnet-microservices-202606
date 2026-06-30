using System.Net.Http.Json;

namespace BlazorApp.Services;

public class ApiCartService(HttpClient _httpClient) : ICartService
{
    public event Action? CartChanged;

    public async Task AddToCartAsync(int productId, int quantity = 1)
    {
        var request = new { productId, quantity };
        var response = await _httpClient.PostAsJsonAsync("api/cart", request);
        response.EnsureSuccessStatusCode();
        CartChanged?.Invoke();
    }

    public async Task RemoveFromCartAsync(int productId)
    {
        var response = await _httpClient.DeleteAsync($"api/cart/{productId}");
        response.EnsureSuccessStatusCode();
        CartChanged?.Invoke();
    }

    public async Task<List<Model.CartItem>?> GetCartItemsAsync() =>
        await _httpClient.GetFromJsonAsync<List<Model.CartItem>>("api/cart");

    public async Task CheckoutAsync()
    {
        var response = await _httpClient.PostAsync("api/cart/checkout", null);
        response.EnsureSuccessStatusCode();
        CartChanged?.Invoke();
    }
}
