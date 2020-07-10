using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using ClothesASPCoreApp.Utility;
using ClothesASPCoreApp.Models.ViewModel;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ImportProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ImportViewModel ImportVM { get; set; }

        public ImportProductController(ApplicationDbContext context)
        {
            _context = context;
            ImportVM = new ImportViewModel()
            {
                SpecialTags = _context.SpecialTags.ToList(),
                ProductTypes = _context.ProductTypes.ToList(),
                Vendors = _context.Vendors.ToList(),
                Products = _context.Products.ToList()
            };
        }

        // GET: Admin/ImportProduct
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ImportProductDetails.Include(i => i.Products);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ImportProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importProductDetails = await _context.ImportProductDetails
                .Include(i => i.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importProductDetails == null)
            {
                return NotFound();
            }

            return View(importProductDetails);
        }

        // GET: Admin/ImportProduct/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Admin/ImportProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateImport,AmountProduct,ProductId")] ImportProductDetails importProductDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Where(a => a.Id == importProductDetails.ProductId).FirstOrDefault().Quantity += importProductDetails.AmountProduct;
                _context.Add(importProductDetails);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", importProductDetails.ProductId);
            return View(importProductDetails);
        }
    }
}
