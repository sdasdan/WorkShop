using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkShop.Models
{
    public class ProductModel
    {
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductCategorieModel> ProductCategorie { get; set; }

    }
}
