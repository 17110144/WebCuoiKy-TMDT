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
        public HomeViewModel HomeVM;
        public ListProductViewModel lsProductVM;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
            HomeVM = new HomeViewModel()
            {
                Products = new List<Products>(),
                SpecialTags = new List<SpecialTags>(),
                News = new List<News>()
            };
        }

        public IActionResult Index()
        {
            var productList = _db.Products.Include(m => m.Brands)
                                            .Include(m => m.Vendors)
                                            .Include(m => m.Categories)
                                            .Include(m => m.ProductTypes)
                                            .Include(m => m.SpecialTags)
                                            .Where(p => p.isPublic == true)
                                            .Where(p => p.Quantity > 0).ToList();
                                            
      


            for (int i = 0; i < productList.Count; i++)
            {
                HomeVM.Products.Add(productList[i]);
            }
            return View(HomeVM);
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
