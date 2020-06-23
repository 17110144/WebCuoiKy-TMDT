using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
using ClothesASPCoreApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

       
        [BindProperty]
        public ProductsViewModel ProductsVM { get; set; }
        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            ProductsVM = new ProductsViewModel()
            {
                Categories = _context.Categories.ToList(),
                Vendors = _context.Vendors.ToList(),
                SpecialTags = _context.SpecialTags.ToList(),
                Products = new Models.Products()
            };
          
        }

        public async Task<IActionResult> Index()
        {
            var products = _context.Products.Include(m => m.Categories).Include(m => m.SpecialTags).Include(m => m.Vendors);
            return View(await products.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(ProductsVM);
        }

        //Post : Products Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(ProductsVM);
            }

            _context.Products.Add(ProductsVM.Products);
            await _context.SaveChangesAsync();

            //lưu ảnh
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productsFromDb = _context.Products.Find(ProductsVM.Products.Id);
            productsFromDb.Update = DateTime.Now;

            if (files.Count != 0)
            {
                //up ảnh
                var uploads = Path.Combine(webRootPath, SD.ProductImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                productsFromDb.Image = @"\" + SD.ProductImageFolder + @"\" + ProductsVM.Products.Id + extension;
            }
            else
            {
                //nếu ko up ảnh thì đưa đến đường dẫn của ảnh mặc định
                var uploads = Path.Combine(webRootPath, SD.DefaultImageFolder + @"\" + SD.DefaultImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ProductImageFolder + @"\" + ProductsVM.Products.Id + ".png");
                productsFromDb.Image = @"\" + SD.ProductImageFolder + @"\" + ProductsVM.Products.Id + ".png";
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.Products = await _context.Products.Include(m => m.SpecialTags).Include(m => m.Categories).Include(m => m.Vendors).SingleOrDefaultAsync(m => m.Id == id);

            if (ProductsVM.Products == null)
            {
                return NotFound();
            }

            return View(ProductsVM);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var productFromDb = _context.Products.Where(m => m.Id == ProductsVM.Products.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, SD.ProductImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(productFromDb.Image);

                    if (System.IO.File.Exists(Path.Combine(uploads, ProductsVM.Products.Id + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, ProductsVM.Products.Id + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    ProductsVM.Products.Image = @"\" + SD.ProductImageFolder + @"\" + ProductsVM.Products.Id + extension_new;
                }

                if (ProductsVM.Products.Image != null)
                {
                    productFromDb.Image = ProductsVM.Products.Image;
                }

                productFromDb.Name = ProductsVM.Products.Name;
                productFromDb.VendorID = ProductsVM.Products.VendorID;
                productFromDb.Update = DateTime.Now;
                productFromDb.Price = ProductsVM.Products.Price;
                productFromDb.Quantity = ProductsVM.Products.Quantity;
                productFromDb.CategoryID = ProductsVM.Products.CategoryID;
                productFromDb.SpecialTagID = ProductsVM.Products.SpecialTagID;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(ProductsVM);
        }


        //GET : Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.Products = await _context.Products.Include(m => m.SpecialTags).Include(m => m.Categories).Include(m => m.Vendors).SingleOrDefaultAsync(m => m.Id == id);

            if (ProductsVM.Products == null)
            {
                return NotFound();
            }

            return View(ProductsVM);
        }

        //GET : Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.Products = await _context.Products.Include(m => m.SpecialTags).Include(m => m.Categories).Include(m => m.Vendors).SingleOrDefaultAsync(m => m.Id == id);

            if (ProductsVM.Products == null)
            {
                return NotFound();
            }

            return View(ProductsVM);
        }

        //POST : Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            Products products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, SD.ProductImageFolder);
                var extension = Path.GetExtension(products.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, products.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, products.Id + extension));
                }
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }


    }
}
