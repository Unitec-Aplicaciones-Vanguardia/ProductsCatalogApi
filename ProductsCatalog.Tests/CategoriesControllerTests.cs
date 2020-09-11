using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsCatalog.API.Controllers;
using ProductsCatalog.Core;
using ProductsCatalog.Core.Models;
using ProductsCatalog.Services;
using ProductsCatalog.Tests.Builders;
using Xunit;

namespace ProductsCatalog.Tests
{
    public class CategoriesControllerTests
    {
        [Theory]
        [InlineData(1)]
        public void GetProducts_ValidCategoryId_Returns200Ok(long categoryId)
        {
            //arrange
            var builder = new CategoriesControllerBuilder();
            var serviceMock = builder.GetDefaultCategoryService();
            
            serviceMock.Setup(c => c.GetProductsByCategory(It.IsAny<long>()))
                .Returns(ServiceResult<IEnumerable<ProductDataTransferObject>>.SuccessResult(
                    Enumerable.Empty<ProductDataTransferObject>()));

            var controller = builder.WithCategoryService(serviceMock.Object).Build();

            //act
            var response = controller.Get(categoryId);

            //assert
            Assert.IsType<OkObjectResult>(response);
            var responseModel =
                Assert.IsAssignableFrom<IEnumerable<ProductDataTransferObject>>((response as OkObjectResult).Value);
            Assert.True(!responseModel.Any());
        }

        [Theory]
        [InlineData(-5)]
        public void GetProducts_ValidCategoryId_Returns400BadRequest(long categoryId)
        {
            //arrange
            var builder = new CategoriesControllerBuilder();
            var serviceMock = builder.GetDefaultCategoryService();

            serviceMock.Setup(c => c.GetProductsByCategory(It.IsAny<long>()))
                .Returns(ServiceResult<IEnumerable<ProductDataTransferObject>>.ErrorResult(string.Empty));

            var controller = builder.WithCategoryService(serviceMock.Object).Build();

            //act
            var response = controller.Get(categoryId);

            //assert
            Assert.IsType<BadRequestObjectResult>(response);
        }

    }
}
