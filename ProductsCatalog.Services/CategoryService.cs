using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Core;
using ProductsCatalog.Core.Models;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceResult<CategoryDataTransferObject> Add(CategoryDataTransferObject category)
        {
            if (string.IsNullOrEmpty(category.Description))
            {
                throw new ArgumentNullException(nameof(category.Description));
            }

            var categoryEntity = new Category
            {
                Description = category.Description
            };

            _categoryRepository.Add(categoryEntity);
            _categoryRepository.SaveChanges();
            category.Id = categoryEntity.Id;

            return ServiceResult<CategoryDataTransferObject>.SuccessResult(category);
        }

        public ServiceResult<IEnumerable<CategoryDataTransferObject>> GetAll()
        {
            var categories = _categoryRepository.All()
                .Select(x => new CategoryDataTransferObject
                {
                    Description = x.Description,
                    Id = x.Id
                });

            return ServiceResult<IEnumerable<CategoryDataTransferObject>>.SuccessResult(categories);
        }

        public ServiceResult<IEnumerable<ProductDataTransferObject>> GetProductsByCategory(long categoryId)
        {
            var category = _categoryRepository.All()
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
            {
                return ServiceResult<IEnumerable<ProductDataTransferObject>>.ErrorResult($"No se encontró una categoría con el id {categoryId}");
            }

            var result = category.Products.Select(x => new ProductDataTransferObject
            {
                Description = x.Description,
                Price = x.Price + (x.Price * 0.15) ,
                CategoryDescription = x.Category.Description,
                CategoryId = x.CategoryId,
                Id = x.Id
            });

            return ServiceResult<IEnumerable<ProductDataTransferObject>>.SuccessResult(result);
        }
    }
}
