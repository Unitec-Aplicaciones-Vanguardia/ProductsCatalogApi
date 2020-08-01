using System;
using System.Collections.Generic;
using ProductsCatalog.Core;
using ProductsCatalog.Core.Models;

namespace ProductsCatalog.Services
{
    public interface IProductService
    {
        ServiceResult<ProductDataTransferObject> Add(ProductDataTransferObject product);

        ServiceResult<IEnumerable<ProductDataTransferObject>> GetAll();
    }
}
