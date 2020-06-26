﻿using System;
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
        private readonly ApplicationDbContext _db;
        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }
        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categories Categories)
        {
            if (ModelState.IsValid)
            {
                _db.Add(Categories);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Categories);
        }


        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Categories = await _db.Categories.FindAsync(id);
            if (Categories == null)
            {
                return NotFound();
            }

            return View(Categories);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categories Categories)
        {
            if (id != Categories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(Categories);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Categories);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Categories = await _db.Categories.FindAsync(id);
            if (Categories == null)
            {
                return NotFound();
            }

            return View(Categories);
        }


        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Categories = await _db.Categories.FindAsync(id);
            if (Categories == null)
            {
                return NotFound();
            }

            return View(Categories);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Categories = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(Categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
