using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCatalog.Core.Models
{
    public class ProductDataTransferObject
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public long CategoryId { get; set; }

        public string CategoryDescription { get; set; }
    }
}
