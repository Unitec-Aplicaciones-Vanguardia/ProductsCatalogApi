using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProductsCatalog.Core;
using ProductsCatalog.Data;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Data.Repositories;
using ProductsCatalog.Tests.Models;

namespace ProductsCatalog.Tests.Builders
{
    public class CategoryRepositoryBuilder
    {
        private Mock<ProductsCatalogContext> _contextMock;
        private bool _useDefaultContext = true;
        private ProductsCatalogContext _context;
        public CategoryRepositoryBuilder WithCategories(IEnumerable<CategoryTestObject> categoriesTestObjects)
        {
            var categories = categoriesTestObjects.Select(c => new Category
            {
                Description = c.Description,
                Id = c.Id,
                Products = c.Products.Select(p => new Product
                {
                    Description = p.Description,
                    Price = p.Price,
                    Id = p.Id
                }).ToList()
            });

            _contextMock ??= new Mock<ProductsCatalogContext>();
            var mockDbSet = new Mock<DbSet<Category>>();
            mockDbSet.As<IQueryable<Category>>().Setup(c => c.Provider).Returns(categories.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Category>>().Setup(c => c.Expression).Returns(categories.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Category>>().Setup(c => c.ElementType).Returns(categories.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Category>>().Setup(c => c.GetEnumerator()).Returns(categories.AsQueryable().GetEnumerator);

            _contextMock.Setup(c => c.Set<Category>())
                .Returns(mockDbSet.Object);
            return this;
        }

        public CategoryRepositoryBuilder WithInMemoryContext(ProductsCatalogContext context)
        {
            _useDefaultContext = false;
            _context = context;
            return this;
        }

        public IRepository<Category> Build()
        {
            if (_useDefaultContext)
                _context = _contextMock.Object;
            return new CategoryRepository(_context);
        }
    }
}
