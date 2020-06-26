using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Extensions;

using Microsoft.EntityFrameworkCore;
using ClothesASPCoreApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothesASPCoreApp.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        //Trang home mặc định chứa tất cả các sản phẩm của shop
        public async Task<IActionResult> Index()
        {
            var productList = await _db.Products.Include(m => m.Categories).Include(m => m.Vendors).Include(m => m.SpecialTags).ToListAsync();

            var ListProductVM = new ListProductViewModel
            {
                Products = productList
            };

            return View(ListProductVM);
        }

        [HttpGet]
        //Trang home sau khi tìm kiếm theo từ khóa hoặc danh mục
        public async Task<IActionResult> Index(string productCate, string searchString)
        {
            IQueryable<string> cateQuery = from m in _db.Categories
                                           orderby m.Name
                                           select m.Name;

            var products = from p in _db.Products select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(productCate))
            {
                products = products.Where(x => x.Categories.Name == productCate);
            }

            var ListProductVM = new ListProductViewModel
            {
                Category = new SelectList(await cateQuery.Distinct().ToListAsync()),
                Products = await products.ToListAsync()
            };

            return View(ListProductVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.Products.Include(m => m.Categories).Include(m => m.Vendors).Include(m => m.SpecialTags).Where(m => m.Id == id).FirstOrDefaultAsync();

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

            return RedirectToAction("Index", "Home", new { area = "Customer" });

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
