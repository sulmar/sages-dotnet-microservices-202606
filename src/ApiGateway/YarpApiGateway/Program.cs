using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// dotnet add package Microsoft.Extensions.ServiceDiscovery
builder.Services.AddServiceDiscovery();

// dotnet add package Yarp.ReverseProxy
// dotnet add package Microsoft.Extensions.ServiceDiscovery.Yarp

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddServiceDiscoveryDestinationResolver();

var secretKey = "a-string-secret-at-least-256-bits-long";

// dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Audience = "microservices";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "identity-service",
            ValidateAudience = true,
            ValidAudience = "microservices",
            ValidateLifetime = true,
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization(options =>
{
   options.AddPolicy("authenticated", policy =>
   {
       policy.RequireAuthenticatedUser();
       policy.RequireClaim("phone");
   });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.Run();
