namespace IdentityProvider.Api.Features.Login;

public static class LoginEndpoint
{
    public static IEndpointRouteBuilder MapLogin(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/login", async (LoginRequest request, LoginHandler handler) =>
        {
            var response = await handler.HandleAsync(request);

            if (response.IsSuccess)
            {
                return Results.Ok(response.AccessToken);
            }
            else
            {
                return Results.Unauthorized();
            }
        });

        return endpoints;
    }
}
