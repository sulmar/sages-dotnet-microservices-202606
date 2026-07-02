using StackExchange.Redis;

namespace Payment.Worker.Infrastructure;

public class PaymentWorker(IConnectionMultiplexer connection) : BackgroundService
{
    private const string StreamName = "orders-stream";
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var db = connection.GetDatabase();
        
        var lastId = "0-0"; // Start from the beginning of the stream

        while (!stoppingToken.IsCancellationRequested)
        {
            // XREAD STREAMS orders-stream 0-0
            var entries = await db.StreamReadAsync(StreamName, lastId);

            foreach (var entry in entries)
            {
                lastId = entry.Id; // Update the last processed ID
                var orderId = entry["orderId"];
                var eventType = entry["type"];
                var occuredAt = entry["occuredAt"];
                var lines = entry["lines"];
                
                // Process the order event (e.g., initiate payment)
                Console.WriteLine($"Processing Order ID: {orderId}, Event Type: {eventType}, Occurred At: {occuredAt}, Lines: {lines}");

                await Task.Delay(500, stoppingToken); // Simulate some processing time

            }
        }

    }
}
