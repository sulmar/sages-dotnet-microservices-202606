using StackExchange.Redis;

namespace Payment.Worker.Infrastructure;

public class GroupPaymentWorker(IConnectionMultiplexer connection, ILogger<GroupPaymentWorker> logger) : BackgroundService
{
    private const string StreamName = "orders-stream";
    private const string GroupName = "payment-group";
    

    private const string NewMessageId = ">"; // Only new messages

    private IDatabase db => connection.GetDatabase();

    private async Task EnsureGroup()
    {
        try
        {
            // XGROUP CREATE orders-stream payment-group $ MKSTREAM
            await db.StreamCreateConsumerGroupAsync(StreamName, GroupName, position: "$", createStream: true);
        }
        catch (RedisServerException e)
        { 
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await EnsureGroup();

        string ConsumerName = $"payment-{Guid.NewGuid()}"; // Unique consumer name

        // string ConsumerName = Environment.GetEnvironmentVariable("INSTANCE_ID"); // Pobierane ze zmiennej srodowiskowej, aby mieć unikalną nazwę konsumenta w klastrze

        var lastId = ""; 

        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Checking for new messages...");
            // XREADGROUP GROUP payment-group payment-1 STREAMS orders-stream > 
            var entries = await db.StreamReadGroupAsync(StreamName, GroupName, ConsumerName, NewMessageId);

            foreach (var entry in entries)
            {
                try
                {
                    lastId = entry.Id; // Update the last processed ID
                    var orderId = entry["orderId"];
                    var eventType = entry["type"];
                    var occuredAt = entry["occuredAt"];
                    var lines = entry["lines"];

                    // Process the order event (e.g., initiate payment)
                    logger.LogInformation("Processing Order ID: {orderId}, Event Type: {eventType}, Occurred At: {occuredAt}, Lines: {lines}", orderId, eventType, occuredAt, lines);

                    // TODO:
                    // - wykonaj platnosc
                    // - opublikuj event PaymentProcessed

                    await Task.Delay(10_000, stoppingToken); // Simulate some processing time

                    // Potwierdzenie ACK
                    // XACK orders-stream payment-group {id}
                    await db.StreamAcknowledgeAsync(StreamName, GroupName, entry.Id); // Acknowledge the message
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error processing entry {entry.Id}", entry.Id);

                    // Brak potwierdzenia ACK
                    // Wiadomosc pozostanie w kolejce do ponownego przetworzenia (pending)
                }
            }

            await Task.Delay(5000, stoppingToken); // Wait before checking for new messages again
        }
    }
}
