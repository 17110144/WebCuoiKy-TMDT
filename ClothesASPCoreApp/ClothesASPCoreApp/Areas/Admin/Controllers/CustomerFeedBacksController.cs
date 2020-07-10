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

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class CustomerFeedBacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerFeedBacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CustomerFeedBacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feedbacks.ToListAsync());
        }

        // GET: Admin/CustomerFeedBacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // GET: Admin/CustomerFeedBacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // POST: Admin/CustomerFeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbacks = await _context.Feedbacks.FindAsync(id);
            _context.Feedbacks.Remove(feedbacks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbacksExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
