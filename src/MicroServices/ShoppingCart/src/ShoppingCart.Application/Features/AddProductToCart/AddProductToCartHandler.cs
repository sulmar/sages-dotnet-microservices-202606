using ShoppingCart.Application.Abstractions;

namespace ShoppingCart.Application.Features.AddProductToCart;

public class AddProductToCartHandler(ICartRepository repository)
{
    public async Task HandleAsync(AddProductToCartRequest request)
    {
        // TODO: pobieraj po autoryzacji
        var cartId = "123abc";

        await repository.IncrementQuantityAsync(cartId, request.ProductId, request.Quantity);
        
    }
}


public record AddProductToCartRequest(int ProductId, int Quantity);