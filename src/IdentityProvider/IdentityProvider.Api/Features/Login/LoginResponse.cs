namespace IdentityProvider.Api.Features.Login;

public record LoginResponse(bool IsSuccess, string Message, string AccessToken = null);
