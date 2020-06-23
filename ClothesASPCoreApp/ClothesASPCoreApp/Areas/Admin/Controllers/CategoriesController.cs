using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }


        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate= await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Categories cate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cate);
        }

        // GET: Admin/Categories/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _context.Categories.FindAsync(id);
            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Categories cate)
        {
            if (id != cate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(cate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cate);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cate = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(cate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

    }
}
