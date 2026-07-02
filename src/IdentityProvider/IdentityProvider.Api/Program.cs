using IdentityProvider.Api.Features.Login;
using IdentityProvider.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LoginHandler>();
builder.Services.AddScoped<JwtTokenGenerator>();

var app = builder.Build();

app.MapGet("/", () => "Hello Identity Provider Api!");

app.MapLogin();

app.Run();
