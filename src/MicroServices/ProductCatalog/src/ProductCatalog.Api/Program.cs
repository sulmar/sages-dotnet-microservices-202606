using ProductCatalog.Api.Features.GetProducts;
using ProductCatalog.Application;
using ProductCatalog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGetProducts();

app.Run();
