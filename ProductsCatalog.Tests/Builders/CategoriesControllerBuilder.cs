using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ProductsCatalog.API.Controllers;
using ProductsCatalog.Services;

namespace ProductsCatalog.Tests.Builders
{
    public class CategoriesControllerBuilder
    {
        private ICategoryService _defaultCategoryService;
        private bool _useDefaultCategoryService = true;

        public CategoriesControllerBuilder WithCategoryService(ICategoryService categoryService)
        {
            _useDefaultCategoryService = false;
            _defaultCategoryService = categoryService;
            return this;
        }

        public CategoriesController Build()
        {
            if (_useDefaultCategoryService)
                _defaultCategoryService = GetDefaultCategoryService().Object;

            return new CategoriesController(_defaultCategoryService);
        }

        public Mock<ICategoryService> GetDefaultCategoryService()
        {
            return new Mock<ICategoryService>();
        }
    }
}
