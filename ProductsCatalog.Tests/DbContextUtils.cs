using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Data;

namespace ProductsCatalog.Tests
{
    public static class DbContextUtils
    {
        public static ProductsCatalogContext GetInMemoryProductsCatalogContext()
        {
            var connection = new SqliteConnection("Data Source=:memory:");

            connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<ProductsCatalogContext>()
                .UseSqlite(connection)
                .Options;

            var context = new ProductsCatalogContext(dbContextOptions);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
