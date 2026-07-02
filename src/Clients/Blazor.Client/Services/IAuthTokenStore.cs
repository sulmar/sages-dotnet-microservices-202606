namespace BlazorApp.Services;

public interface IAuthTokenStore
{
    ValueTask<string?> GetTokenAsync();

    ValueTask SetTokenAsync(string token);

    ValueTask ClearTokenAsync();
}
