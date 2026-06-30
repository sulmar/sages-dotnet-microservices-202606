using Dapper;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Domain.Products;
using System.Data;
using System.Data.Common;

namespace ProductCatalog.Infrastructure.Persistance;

public class SqliteProductRepository(DbConnection connection) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        await EnsureConnectionOpenAsync();

        const string sql = """

        SELECT Id, Name, Description, Price, DiscountedPrice
        FROM Products
        ORDER BY Name;

        """;

        var result = await connection.QueryAsync<Product>(sql);

        return result.ToList();
    }

    private async Task EnsureConnectionOpenAsync()
    {
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }
    }
}