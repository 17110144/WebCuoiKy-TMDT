using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Extensions;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClothesASPCoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ListProductViewModel lsProductVM;
        public ShoppingViewModel ShoppingVM;
        public ShoppingController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingVM = new ShoppingViewModel()
            {
                Products = new List<Products>(),
                Brands = new List<Brands>(_db.Brands.ToList()),
                Categories = new List<Categories>(),
                ProductTypes = new List<ProductTypes>(),
                SpecialTags = new List<SpecialTags>(),
            };
        }

        public IActionResult Index()
        {
            var lsproduct = _db.Products.Include(m => m.Brands)
                                            .Include(m => m.Vendors)
                                            .Include(m => m.Categories)
                                            .Include(m => m.ProductTypes)
                                            .Include(m => m.SpecialTags)
                                            .Where(p => p.isPublic == true)
                                            .Where(p => p.Quantity > 0).ToList();

            for (int i = 0; i < lsproduct.Count; i++)
            {
                ShoppingVM.Products.Add(lsproduct[i]);
            }
            return View(ShoppingVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.Products.Include(m => m.Brands)
                                            .Include(m => m.Vendors)
                                            .Include(m => m.Categories)
                                            .Include(m => m.ProductTypes)
                                            .Include(m => m.SpecialTags)
                                            .Where(m => m.Id == id).FirstOrDefaultAsync();

            return View(product);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsPost(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart == null)
            {

                lstShoppingCart = new List<int>();
            }
            lstShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction("Index", "Shopping", new { area = "Customer" });

        }

        public IActionResult Remove(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart.Count > 0)
            {
                if (lstShoppingCart.Contains(id))
                {
                    lstShoppingCart.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
