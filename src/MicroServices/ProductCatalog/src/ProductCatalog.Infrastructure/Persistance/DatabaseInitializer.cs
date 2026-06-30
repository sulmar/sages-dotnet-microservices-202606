using Dapper;
using Microsoft.Data.Sqlite;
using ProductCatalog.Domain.Products;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ProductCatalog.Infrastructure.Persistance;

// dotnet add package Microsoft.Data.Sqlite
public sealed class DatabaseInitializer(DbConnection connection, IDictionary<int, Product> products)
{
    public async Task InitializeAsync()
    {        
        await connection.OpenAsync();

        await using var command = connection.CreateCommand();

        command.CommandText = """"
            CREATE TABLE IF NOT EXISTS Products
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Description TEXT NOT NULL,
                Price REAL NOT NULL,
                DiscountedPrice REAL NULL
            );

            """";

        await command.ExecuteNonQueryAsync();

        // dotnet add package Dapper
        var count = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Products");

        if (count == 0)
        {
            await connection.ExecuteAsync("""
                INSERT INTO Products (Id, Name, Description, Price, DiscountedPrice)
                VALUES (@Id, @Name, @Description, @Price, @DiscountedPrice);
                """, products.Values);
        }
    }
}
