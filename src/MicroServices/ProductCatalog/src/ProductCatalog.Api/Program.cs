using ProductCatalog.Api;
using ProductCatalog.Api.Features.GetProducts;
using ProductCatalog.Application;
using ProductCatalog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

await app.InitializeDatabaseAsync();


app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers["X-Server"] = Environment.MachineName;
        context.Response.Headers["X-Server-Port"] =
            context.Connection.LocalPort.ToString();

        return Task.CompletedTask;
    });

    await next();
});

app.MapGet("/", () => "Hello Product Catalog Api!");
app.MapGetProducts();

app.Run();
