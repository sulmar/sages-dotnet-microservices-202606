using ShoppingCart.Application.Abstractions;

namespace ShoppingCart.Application.Features.GetCartProducts;

public class GetCartProductHandler(ICartRepository repository)
{
    public async Task<List<CartItemResponse>> HandleAsync()
    {
        // TODO: pobieraj po autoryzacji
        var cartId = "123abc";

        var result = await repository.GetAllAsync(cartId);

        return result.Select(x => new CartItemResponse(x.ProductId, x.Quantity)).ToList();
    }

    public record CartItemResponse(int ProductId, int Quantity);
}

