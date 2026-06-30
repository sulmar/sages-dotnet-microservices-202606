using ProductCatalog.Api.Features.GetProducts;
using ProductCatalog.Application;
using ProductCatalog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Read", policy =>
    {
        policy.AllowAnyOrigin();
        policy.WithMethods("GET");
        policy.AllowAnyHeader();        
    });
});

builder.Services.AddAplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseCors("Read");

app.MapGet("/", () => "Hello Product Catalog Api!");
app.MapGetProducts();

app.Run();
