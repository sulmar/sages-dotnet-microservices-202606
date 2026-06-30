using ShoppingCart.Application.Abstractions;
using StackExchange.Redis;

namespace ShoppingCart.Infrastructure.Persistance;

// dotnet add package StackExchange.Redis
public class RedisCartRepository(IConnectionMultiplexer connection) : ICartRepository
{
    private static readonly TimeSpan CartExpiration = TimeSpan.FromMinutes(2);

    private IDatabase db => connection.GetDatabase();

    public async Task IncrementQuantityAsync(string cartId, int productId, int quantity)
    {
        // HINCRBY cart:{cartId} {productId} {quantity}
        // np. HINCRBY cart:123abc product:2 1

        var key = $"cart:{cartId}";
        var field = $"product:{productId}";

        await db.HashIncrementAsync(key, field, quantity);

        // EXPIRE cart:{cartId} 120
        await db.KeyExpireAsync(key, CartExpiration);        
    }
}
