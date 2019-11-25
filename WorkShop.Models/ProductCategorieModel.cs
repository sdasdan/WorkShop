using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShop.Models
{
    public class ProductCategorieModel
    {
        public Guid Id { get; set; } 

        public Guid ProductId { get; set; }

        public Guid CategorieId { get; set; }

        public ProductModel Product { get; set; }

        public CategorieModel Categorie { get; set; }

    }
}
