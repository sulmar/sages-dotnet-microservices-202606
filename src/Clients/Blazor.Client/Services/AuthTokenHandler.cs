using System.Net.Http.Headers;
using System.Net;

namespace BlazorApp.Services;

public sealed class AuthTokenHandler(IAuthTokenStore tokenStore) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await tokenStore.GetTokenAsync();

        if (!string.IsNullOrWhiteSpace(token) && request.Headers.Authorization is null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await tokenStore.ClearTokenAsync();
        }

        return response;
    }
}
