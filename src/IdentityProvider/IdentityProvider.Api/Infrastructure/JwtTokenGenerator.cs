using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace IdentityProvider.Api.Infrastructure;

public class JwtTokenGenerator
{

    // dotnet add package Microsoft.IdentityModel.JsonWebTokens

    public string Generate(string userId, string username)
    {
        var expiresAt = DateTime.UtcNow.AddMinutes(5);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a-string-secret-at-least-256-bits-long"));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new Dictionary<string, object>
        {
            ["sub"] = userId,
            ["name"] = username,
            ["exp"] = expiresAt.ToString("o")
        };

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = "a",
            Audience = "b",
            Claims = claims,
            Expires = expiresAt,
            SigningCredentials = credentials
        };

        var tokenHandler = new JsonWebTokenHandler();

        return tokenHandler.CreateToken(descriptor);
    }
}
