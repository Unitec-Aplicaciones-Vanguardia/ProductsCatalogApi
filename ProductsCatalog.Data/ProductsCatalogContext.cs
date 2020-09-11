using System;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Data
{
    public class ProductsCatalogContext : DbContext
    {
        public ProductsCatalogContext()
        {
            
        }

        public ProductsCatalogContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
