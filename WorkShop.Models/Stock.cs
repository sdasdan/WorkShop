using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShop.Models
{
   public class Stock
    {
        public Guid Id { get; set; }

        public ICollection<Product> Products { get; set; }

        public int stock { get; set; }
    }
}
