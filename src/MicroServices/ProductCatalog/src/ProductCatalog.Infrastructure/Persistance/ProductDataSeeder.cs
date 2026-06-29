using Bogus;
using ProductCatalog.Domain.Products;

namespace ProductCatalog.Infrastructure.Persistance;

// dotnet add package Bogus

public static class ProductDataSeeder
{
    private const int ProductCount = 24;

    public static IDictionary<int, Product> Seed()
    {
        var faker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p=>p.Description, f=>f.Commerce.ProductDescription())
            .RuleFor(p=>p.Price, f=> Math.Round( f.Random.Decimal(10, 200), 2))
            .RuleFor(p => p.DiscountedPrice, (f, product) => Math.Round(f.Random.Decimal(10, product.Price), 2));

        var products = faker.Generate(ProductCount);

        return products.ToDictionary(p => p.Id);

    }
}
