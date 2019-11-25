using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShop.Models;

namespace WorkShop.Web.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CategorieModel> Categories { get; set; }


    }
}
