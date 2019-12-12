using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            return Redirect($"Details/{model.Id}");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _context.Products
                .Include(p => p.ProductCategorie)
                .ThenInclude(pc => pc.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);

            var prodCat = _context.Set<ProductCategorieModel>()
                .Where(x => x.ProductId == id)
                .Select(x => x).ToArray();

            var cat = await _context.Categories.ToListAsync();

            var productCat = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
            };

            productCat.Assigned = new List<CheckboxPermissions>();

            foreach (var item in cat)
            {
                var assigned = new CheckboxPermissions
                {
                    Id = item.Id,
                    Name = item.Name,
                    Selected = (prodCat.Select(x => x.CategorieId).Contains(item.Id) ? true : false)
                };
                // (product.ProductCategorie.Select(x => x.CategorieId).Contains(Id)
                productCat.Assigned.Add(assigned);
            }


            if (product == null)
            {
                return NotFound();
            }

            return View(productCat);
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

        public async Task<IActionResult> Delete(Guid id)
        {
            var prodcat = _context.Set<ProductCategorieModel>().Where(x => x.ProductId == id).Select(x => x).ToArray();
            _context.Set<ProductCategorieModel>().RemoveRange(prodcat);

            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
