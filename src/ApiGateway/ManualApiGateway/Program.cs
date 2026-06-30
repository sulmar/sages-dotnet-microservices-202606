using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Host.Port == 7000)
    {
        var newUrl = $"https://localhost:7001{context.Request.Path}{context.Request.QueryString}";

        context.Response.Redirect(newUrl, permanent: false);
        return;
    }

    await next();
});

var options = new RewriteOptions()
    .AddRewrite("^$", "ping", skipRemainingRules: true);

app.UseRewriter(options);

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", () => "Pong");

app.Run();
