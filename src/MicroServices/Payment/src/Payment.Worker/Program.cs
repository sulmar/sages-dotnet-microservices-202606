using Payment.Worker.Workers;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<PaymentWorker>();
builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379"));

var app = builder.Build();

app.MapGet("/", () => "Hello Payment Worker!");

app.Run();
