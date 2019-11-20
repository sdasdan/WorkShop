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

        public Guid Id { get; set; } = System.Guid.NewGuid();
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Error()
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

        [Route("[action]")]
        public IActionResult Create(string name)
        {
            var model = new CategorieModel();
            model.Id = this.Id;
            model.Name = name;

            if (ModelState.IsValid)
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return Redirect($"Categorie/Details/{model.Id}");
            }
            else
            {
                return Problem("erreur insertion db","Error",0,"Erreur");
            }
        }

    
    }
}
