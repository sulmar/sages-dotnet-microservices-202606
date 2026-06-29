namespace ProductCatalog.Application.Features.GetProducts;

// Record (.NET 8)
public record ProductListItemDto(int Id, string Name, decimal Price, decimal DiscountedPrice);
