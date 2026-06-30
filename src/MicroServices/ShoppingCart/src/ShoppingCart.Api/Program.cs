using ShoppingCart.Api.Features.AddProductToCart;
using ShoppingCart.Application;
using ShoppingCart.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.WithMethods("POST");
        policy.AllowAnyHeader();
    });
});


builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello Cart Api!");

app.MapAddProductToCartEndpoint();

app.Run();
