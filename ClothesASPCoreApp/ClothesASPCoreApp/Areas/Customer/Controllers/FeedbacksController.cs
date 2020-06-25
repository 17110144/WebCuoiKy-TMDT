using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Area("Customer")]
    public class FeedbacksController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FeedbacksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Feedbacks.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }
        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feedbacks Feedbacks)
        {
            if (ModelState.IsValid)
            {
                Feedbacks.Date = DateTime.Now;
                _db.Add(Feedbacks);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Feedbacks);
        }
        //GET Delete Action Method

        //[Authorize(Roles = SD.SuperAdminEndUser)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Feedbacks = await _db.Feedbacks.FindAsync(id);
            if (Feedbacks == null)
            {
                return NotFound();
            }

            return View(Feedbacks);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Feedbacks = await _db.Feedbacks.FindAsync(id);
            _db.Feedbacks.Remove(Feedbacks);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}