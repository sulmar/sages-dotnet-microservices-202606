namespace BlazorApp.Services;

public interface ICartService
{
    event Action? CartChanged;

    Task AddToCartAsync(int productId, int quantity = 1);

    Task RemoveFromCartAsync(int productId);

    Task<List<Model.CartItem>?> GetCartItemsAsync();

    Task CheckoutAsync();
}
