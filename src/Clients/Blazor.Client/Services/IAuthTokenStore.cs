namespace BlazorApp.Services;

public interface IAuthTokenStore
{
    event Action? TokenChanged;

    ValueTask<string?> GetTokenAsync();

    ValueTask SetTokenAsync(string token);

    ValueTask ClearTokenAsync();
}
