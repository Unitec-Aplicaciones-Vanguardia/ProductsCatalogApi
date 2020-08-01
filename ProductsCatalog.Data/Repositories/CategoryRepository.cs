using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductsCatalog.Core;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ProductsCatalogContext _context;

        public CategoryRepository(ProductsCatalogContext context)
        {
            _context = context;
        }
        public Category Add(Category entity)
        {
            _context.Category.Add(entity);
            return entity;
        }

        public IQueryable<Category> All()
        {
            return _context.Category;
        }

        public Category GetById(long id)
        {
            return _context.Category.FirstOrDefault(x => x.Id == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
