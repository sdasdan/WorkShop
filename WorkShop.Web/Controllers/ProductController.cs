using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkShop.Models;

namespace WorkShop.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

       
    }
}
