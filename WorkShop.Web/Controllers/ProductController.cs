using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorkShop.DataAccess;
using WorkShop.Models;
using WorkShop.Web.ViewModels;

namespace WorkShop.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly WorkShopDbcontext _context;

        public ProductController(WorkShopDbcontext context)
        {
            _context = context;
        }
        public Guid Id { get; set; } = System.Guid.NewGuid();

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        public IActionResult Add(ProductViewModel model)
        {
            model.Categories = _context.Categories.ToList();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(string name, Guid[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                return Problem("erreur insertion db", "Error", 0, "Erreur");
            }

            var model = new ProductModel();
            model.Id = this.Id;
            model.Name = name;

            await _context.Products.AddAsync(model);

            await _context.Set<ProductCategorieModel>().AddRangeAsync(selectedCategories.Select(c => new ProductCategorieModel
            {
                Id = System.Guid.NewGuid(),
                ProductId = model.Id,
                CategorieId = c
            }));

            await _context.SaveChangesAsync();

            return RedirectToAction($"Details");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Products = await _context.Products.Include(p => p.ProductCategorie).ThenInclude(pc => pc.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Products == null)
            {
                return NotFound();
            }

            return View(Products);
        }
    }
}
