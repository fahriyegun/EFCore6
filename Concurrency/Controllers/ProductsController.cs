using Concurrency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Concurrency.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Update(int id)
        {
            var product =await _context.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
          

            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.First();

                var currentValues = exceptionEntry.Entity as Product;
                var databaseValues = exceptionEntry.GetDatabaseValues();
                var clientValues = exceptionEntry.CurrentValues;

                if(databaseValues == null) //silinmiştir
                {
                    ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından silindi.");
                }
                else //update edilmiştir
                {
                    ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından güncellendi.");
                }
                return View(product);
            }
        }

        public async Task<IActionResult> List()
        {
            return View(_context.Products.ToList());
        }
    }
}
