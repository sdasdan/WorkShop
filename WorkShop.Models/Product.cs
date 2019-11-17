using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShop.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public ICollection<Categorie> Categories { get; set; }

        public string Name { get; set; }
       
    }
}
