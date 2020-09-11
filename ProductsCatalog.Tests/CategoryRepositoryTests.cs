using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Tests.Builders;
using ProductsCatalog.Tests.Models;
using RandomTestValues;
using Xunit;

namespace ProductsCatalog.Tests
{
    public class CategoryRepositoryTests
    {
        [Fact]
        public void All_ExistingElements_ReturnsNonEmptyList()
        {
            var categories = RandomValue.List<CategoryTestObject>();
            var builder = new CategoryRepositoryBuilder();
            var repository = builder.WithCategories(categories).Build();

            var result = repository.All().ToList();
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("Category 1")]
        public void Add_ValidCategory_Succeeds(string description)
        {
            var builder = new CategoryRepositoryBuilder();
            var repository = builder.WithInMemoryContext(DbContextUtils.GetInMemoryProductsCatalogContext()).Build();

            var result = repository.Add(new Category
            {
                Description = description
            });

            repository.SaveChanges();

            Assert.Equal(description, result.Description);
        }
    }
}
