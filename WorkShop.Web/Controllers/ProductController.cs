using Microsoft.AspNetCore.Mvc;


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
