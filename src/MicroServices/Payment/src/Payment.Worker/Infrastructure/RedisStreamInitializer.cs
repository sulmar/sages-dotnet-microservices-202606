using StackExchange.Redis;

namespace Payment.Worker.Infrastructure;

public class RedisStreamInitializer(IConnectionMultiplexer connection)
{
    private const string StreamName = "orders-stream";
    private const string GroupName = "payment-group";

    public async Task InitializeAsync()
    {
        var db = connection.GetDatabase();


        try
        {
            // XGROUP CREATE orders-stream payment-group $ MKSTREAM
            await db.StreamCreateConsumerGroupAsync(StreamName, GroupName, "$", createStream: true);
        }
        catch (Exception ex)
        {
        }

        //  XINFO GROUPS orders-stream
        //var groups = await db.StreamGroupInfoAsync(StreamName);

        //if (groups.Any(g => g.Name == GroupName))
        //{
        //    Console.WriteLine($"Group '{GroupName}' already exists for stream '{StreamName}'.");
        //}
        //else
        //{
        //    // XGROUP CREATE orders-stream payment-group $ MKSTREAM
        //    await db.StreamCreateConsumerGroupAsync(StreamName, GroupName, "$", createStream: true);

        //    Console.WriteLine($"Group '{GroupName}' created for stream '{StreamName}'.");
        //}

    
    }
}
