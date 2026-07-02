using IdentityProvider.Api.Infrastructure;

namespace IdentityProvider.Api.Features.Login;

public class LoginHandler(JwtTokenGenerator generator)
{
    public Task<LoginResponse> HandleAsync(LoginRequest request)
    {
        // Implement your login logic here
        // For example, validate the username and password against a database
        if (request.Username == "john" && request.Password == "123")
        {
            var accessToken = generator.Generate(request.Username, request.Username); // Generate a JWT or any other token here

            return Task.FromResult(new LoginResponse(true, "Login successful", accessToken));
        }
        else
        {
            return Task.FromResult(new LoginResponse(false, "Invalid username or password"));
        }
    }
}
