using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using ProductsCatalog.Core;
using ProductsCatalog.Core.Models;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Tests.Builders;
using Xunit;

namespace ProductsCatalog.Tests
{
    public class CategoryServiceTests
    {
        [Theory]
        [InlineData("Category 1")]
        public void Add_ValidCategoryDescription_Succeeds(string description)
        {
            //arrange
            var expected = new CategoryDataTransferObject
            {
                Description = description
            };

            var builder = new CategoryServiceBuilder();
            var mock = builder.GetDefaultCategoryRepository();
            mock.Setup(r => r.Add(It.IsAny<Category>()))
                .Returns(new Category
                {
                    Description = description,
                    Id = 1
                });
            mock.Setup(r => r.SaveChanges())
                .Returns(1);

            var service = builder.WithCategoryRepository(mock.Object).Build();

            //act
            var result = service.Add(expected);

            //assert
            Assert.Equal(ResponseCode.Success, result.ResponseCode);
            Assert.Equal(description, result.Result.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Add_InvalidCategoryDescription_Succeeds(string description)
        {
            //arrange
            var expected = new CategoryDataTransferObject
            {
                Description = description
            };

            var service = new CategoryServiceBuilder().Build();

            //assert
            Assert.Throws<ArgumentNullException>("Description", () => service.Add(expected));
        }

        [Fact]
        public void GetAll_ExistingElements_ReturnsCorrectList()
        {
            //arrange
            var expectedResults = GetProducts();
            var builder = new CategoryServiceBuilder();
            var repositoryMock = builder.GetDefaultCategoryRepository();
            repositoryMock.Setup(r => r.All())
                .Returns(expectedResults.AsQueryable());

            var service = new CategoryServiceBuilder()
                .WithCategoryRepository(repositoryMock.Object)
                .Build();

            //act
            var result = service.GetAll();

            //assert
            Assert.Equal(ResponseCode.Success, result.ResponseCode);
            foreach (var categoryDataTransferObject in result.Result)
            {
                var category = expectedResults.First(x => x.Description == categoryDataTransferObject.Description);
                Assert.Equal(category.Description, categoryDataTransferObject.Description);
            }
        }

        private Category[] GetProducts()
        {
            return new Category[]
            {
                new Category
                {
                    Description = "desc 1"
                },
                new Category
                {
                    Description = "desc 1"
                },
                new Category
                {
                    Description = "desc 1"
                },
                new Category
                {
                    Description = "desc 1"
                }
            };
        }

    }
}
