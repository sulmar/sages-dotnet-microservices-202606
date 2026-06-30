using ProductCatalog.Infrastructure.Persistance;

namespace ProductCatalog.Api
{
    public static class WebApplicationExtensions
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initializer = scope.ServiceProvider
                .GetRequiredService<DatabaseInitializer>();

            await initializer.InitializeAsync();
        }
    }
}
