using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductsCatalog.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
