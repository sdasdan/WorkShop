using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop.Models
{
    [Table("ProductCategorie")]
    public class ProductCategorieModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid CategorieId { get; set; }

        public ProductModel Product { get; set; }

        public CategorieModel Categorie { get; set; }

    }
}
