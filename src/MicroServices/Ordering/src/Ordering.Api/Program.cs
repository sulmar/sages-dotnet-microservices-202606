using Ordering.Api.Features.CreateOrder;
using Ordering.Api.Hubs;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSignalR();


var app = builder.Build();

app.MapGet("/", () => "Hello Ordering Api!");

app.MapCreateOrderEndpoint();
app.MapHub<OrdersHub>("/hubs/orders");


app.Run();
