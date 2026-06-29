using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Domain.Products;

// Encja
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
}
