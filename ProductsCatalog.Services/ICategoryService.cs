using System;
using System.Collections.Generic;
using System.Text;
using ProductsCatalog.Core;
using ProductsCatalog.Core.Models;

namespace ProductsCatalog.Services
{
    public interface ICategoryService
    {
        ServiceResult<CategoryDataTransferObject> Add(CategoryDataTransferObject category);

        ServiceResult<IEnumerable<CategoryDataTransferObject>> GetAll();

        ServiceResult<IEnumerable<ProductDataTransferObject>> GetProductsByCategory(long categoryId);
    }
}
