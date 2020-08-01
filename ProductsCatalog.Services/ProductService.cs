using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductsCatalog.Core;
using ProductsCatalog.Core.Models;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public ServiceResult<ProductDataTransferObject> Add(ProductDataTransferObject product)
        {
            var productEntity = new Product
            {
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId
            };

            _productRepository.Add(productEntity);
            _productRepository.SaveChanges();
            product.Id = productEntity.Id;
            return ServiceResult<ProductDataTransferObject>.SuccessResult(product);
        }

        public ServiceResult<IEnumerable<ProductDataTransferObject>> GetAll()
        {
            var products = _productRepository.All()
                .Select(x => new ProductDataTransferObject
                {
                    Description = x.Description,
                    Price = x.Price,
                    CategoryId = x.CategoryId,
                    CategoryDescription = x.Category.Description,
                    Id = x.Id
                });
            
            return ServiceResult<IEnumerable<ProductDataTransferObject>>.SuccessResult(products);
        }
    }
}
