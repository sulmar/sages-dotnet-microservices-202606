namespace BlazorApp.Model;

public record OrderStatusChanged(
    string OrderId,
    string Status);
