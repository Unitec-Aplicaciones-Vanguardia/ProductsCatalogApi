using System;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Data
{
    public class ProductsCatalogContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=Data.db");
    }
}
