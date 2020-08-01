using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductsCatalog.Core;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ProductsCatalogContext _context;

        public ProductRepository(ProductsCatalogContext context)
        {
            _context = context;
        }

        public Product Add(Product entity)
        {
            _context.Product.Add(entity);
            return entity;
        }

        public IQueryable<Product> All()
        {
            return _context.Product;
        }

        public Product GetById(long id)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
