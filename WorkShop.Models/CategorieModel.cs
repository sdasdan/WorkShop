using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkShop.Models
{
    public class CategorieModel
    {
        public Guid Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public ICollection<ProductCategorieModel>ProductCategorie { get; set; }

}
}
