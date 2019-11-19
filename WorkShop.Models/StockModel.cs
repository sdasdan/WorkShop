using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShop.Models
{
   public class StockModel
    {
        public Guid Id { get; set; }

        public ICollection<ProductModel> Products { get; set; }

        public int stock { get; set; }
    }
}
