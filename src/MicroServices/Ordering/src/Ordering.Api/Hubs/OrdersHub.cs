using Microsoft.AspNetCore.SignalR;

namespace Ordering.Api.Hubs;

public class OrdersHub : Hub;

public record OrderStatusChanged(
    string OrderId,
    string Status);
