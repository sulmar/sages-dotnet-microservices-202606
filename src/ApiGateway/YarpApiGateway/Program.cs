var builder = WebApplication.CreateBuilder(args);

// dotnet add package Microsoft.Extensions.ServiceDiscovery
builder.Services.AddServiceDiscovery();

// dotnet add package Yarp.ReverseProxy
// dotnet add package Microsoft.Extensions.ServiceDiscovery.Yarp

builder.Services.AddReverseProxy()    
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.MapReverseProxy();

app.Run();
