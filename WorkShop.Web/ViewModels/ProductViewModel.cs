using System;
using System.Collections.Generic;
using WorkShop.Models;

namespace WorkShop.Web.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CategorieModel> Categories { get; set; }

        public List<CheckboxPermissions> Assigned { get; set; }

    }

    public class CheckboxPermissions
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }
    }
}
