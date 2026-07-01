using ShoppingCart.Application.Abstractions;

namespace ShoppingCart.Application.Features.Checkout;

public class CheckoutHandler(ICartRepository repository, IOrderingClient orderingClient)
{
    public async Task HandleAsync()
    {
        var cartId = "123abc"; // TODO: pobieraj po autoryzacji

        var items = await repository.GetAllAsync(cartId);

        var lines = items.Select(i => new OrderLineRequest(i.ProductId, i.Quantity)).ToList();

        var orderRequest = new CreateOrderRequest(lines);
        
        await orderingClient.CreateOrderAsync(orderRequest);

        // TODO: wyczysc koszyk po zlozeniu zamowienia
    }
}
