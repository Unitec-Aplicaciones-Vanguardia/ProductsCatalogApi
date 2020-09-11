using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ProductsCatalog.Core;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Services;

namespace ProductsCatalog.Tests.Builders
{
    public class CategoryServiceBuilder
    {
        private IRepository<Category> _defaultCategoryRepository;
        private bool _useDefaultRepository;

        public CategoryServiceBuilder WithCategoryRepository(IRepository<Category> categoryRepository)
        {
            _useDefaultRepository = false;
            _defaultCategoryRepository = categoryRepository;
            return this;
        }

        public Mock<IRepository<Category>> GetDefaultCategoryRepository() => new Mock<IRepository<Category>>();

        public ICategoryService Build()
        {
            if (_useDefaultRepository)
                _defaultCategoryRepository = GetDefaultCategoryRepository().Object;

            return new CategoryService(_defaultCategoryRepository);
        }
    }
}
