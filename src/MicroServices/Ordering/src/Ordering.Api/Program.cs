using Ordering.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplication();

//builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.MapGet("/", () => "Hello Ordering Api!");

app.Run();
