using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkShop.DataAccess;
using WorkShop.Models;

namespace WorkShop.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly WorkShopDbcontext _context;

        public ProductController(WorkShopDbcontext context)
        {
            _context = context;
        }

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
