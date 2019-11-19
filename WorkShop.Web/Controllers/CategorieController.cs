using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShop.DataAccess;
using WorkShop.Models;

namespace WorkShop.Web.Controllers
{
    public class CategorieController : Controller
    {
        private readonly WorkShopDbcontext _context;

        public CategorieController(WorkShopDbcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        public IActionResult AddCategorie()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult NewCategorie()
        {
            return PartialView("DetailCategorie");
        }
    }
}
