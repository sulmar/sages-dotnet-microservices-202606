namespace Payment.Worker.Infrastructure;

public class RedisStreamInit(RedisStreamInitializer initializer) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await initializer.InitializeAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
