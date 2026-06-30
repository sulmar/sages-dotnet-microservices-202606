using System.Net.Http.Json;

namespace BlazorApp.Services;

public class ApiProductService(HttpClient _httpClient) : IProductService
{
    public async Task<List<Model.Product>?> GetAllAsync() => await _httpClient.GetFromJsonAsync<List<Model.Product>>("api/products");
}
