using ShoppingCart.Application.Abstractions;
using ShoppingCart.Domain.Cart;
using StackExchange.Redis;

namespace ShoppingCart.Infrastructure.Persistance;

// dotnet add package StackExchange.Redis
public class RedisCartRepository(IConnectionMultiplexer connection) : ICartRepository
{
    private static readonly TimeSpan CartExpiration = TimeSpan.FromMinutes(2);

    private IDatabase db => connection.GetDatabase();

    private string GetKey(string cartId) => $"cart:{cartId}";
    private string GetField(int productId) => $"product:{productId}";

    public async Task<List<CartItem>> GetAllAsync(string cartId)
    {
        var key = GetKey(cartId);
        var entries = await db.HashGetAllAsync(key);

        return entries.Select(e => new CartItem(int.Parse(e.Name.ToString().Replace("product:", "")), (int)e.Value)).ToList();
    }


    public async Task IncrementQuantityAsync(string cartId, int productId, int quantity)
    {
        // HINCRBY cart:{cartId} {productId} {quantity}
        // np. HINCRBY cart:123abc product:2 1

        var key = GetKey(cartId);
        var field = GetField(productId);

        await db.HashIncrementAsync(key, field, quantity);

        // EXPIRE cart:{cartId} 120
        await db.KeyExpireAsync(key, CartExpiration);        
    }
}
