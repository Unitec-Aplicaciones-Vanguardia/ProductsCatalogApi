using System;
using System.Collections.Generic;
using System.Text;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Tests.Models
{
    public class CategoryTestObject
    {
        public CategoryTestObject()
        {
            this.Products = new List<ProductTestObject>();
        }

        public long Id { get; set; }

        public string Description { get; set; }

        public ICollection<ProductTestObject> Products { get; set; }
    }
}
