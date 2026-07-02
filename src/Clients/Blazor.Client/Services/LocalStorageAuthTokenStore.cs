using Microsoft.JSInterop;

namespace BlazorApp.Services;

public sealed class LocalStorageAuthTokenStore(IJSRuntime jsRuntime) : IAuthTokenStore
{
    private const string TokenKey = "access_token";

    public async ValueTask<string?> GetTokenAsync() =>
        await jsRuntime.InvokeAsync<string?>("localStorage.getItem", TokenKey);

    public async ValueTask SetTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            await ClearTokenAsync();
            return;
        }

        await jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
    }

    public async ValueTask ClearTokenAsync() =>
        await jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
}
