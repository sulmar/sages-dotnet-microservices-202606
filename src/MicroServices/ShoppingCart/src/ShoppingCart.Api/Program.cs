using ShoppingCart.Api.Features.GetCartProducts;
using ShoppingCart.Application;
using ShoppingCart.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello Cart Api!");

app.MapHandlerEndpoints();

app.Run();
