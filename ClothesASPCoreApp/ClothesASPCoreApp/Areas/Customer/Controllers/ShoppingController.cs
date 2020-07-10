using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        [HttpGet]

        public async Task<IActionResult> Index(string productName, string productType, string productVendor, string productBrand)
        {
            var lsproduct = _db.Products.Include(m => m.Brands)
                                            .Include(m => m.Vendors)
                                            .Include(m => m.Categories)
                                            .Include(m => m.ProductTypes)
                                            .Include(m => m.SpecialTags)
                                            .Where(p => p.isPublic == true)
                                            .Where(p => p.Quantity > 0).ToList();
           
          

         
            if (productName != null)
            {

                lsproduct =  lsproduct.Where(a => a.Name.ToLower().Contains(productName.ToLower())).ToList();
            }
            if (productType != null)
            {
                lsproduct = lsproduct.Where(a => a.ProductTypes.Name.ToLower().Contains(productType.ToLower())).ToList();
            }

            if (productVendor != null)
            {
                lsproduct = lsproduct.Where(a => a.Vendors.Name.ToLower().Contains(productVendor.ToLower())).ToList();
            }

            if (productBrand != null)
            {
                lsproduct = lsproduct.Where(a => a.Brands.Name.ToLower().Contains(productBrand.ToLower())).ToList();
            }


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
        public async Task<IActionResult> DetailsPost(int id, int quantity)
        {
            List<NumberOfProducts> lstShoppingCart = HttpContext.Session.Get<List<NumberOfProducts>>("ssShoppingCart");
            if (lstShoppingCart == null)
            {

                lstShoppingCart = new List<NumberOfProducts>();
            }
            lstShoppingCart.Add(new NumberOfProducts()
            {
                IdProduct = id,
                Quantity = quantity
            });
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction("Index", "Shopping", new { area = "Customer" });

        }

        public IActionResult Remove(int id)
        {
            List<NumberOfProducts> lstShoppingCart = HttpContext.Session.Get<List<NumberOfProducts>>("ssShoppingCart");
            if (lstShoppingCart.Count > 0)
            {
                foreach (NumberOfProducts item in lstShoppingCart)
                {
                    if (item.IdProduct == id)
                    {
                        lstShoppingCart.Remove(item);

                        break;
                    }
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
