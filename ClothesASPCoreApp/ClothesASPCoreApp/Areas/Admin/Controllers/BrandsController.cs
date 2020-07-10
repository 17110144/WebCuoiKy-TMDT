using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
using ClothesASPCoreApp.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _iWebHostEnvironment;


        public BrandsController(ApplicationDbContext db, IWebHostEnvironment iWebHostEnvironment)
        {
            _db = db;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_db.Brands.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brands Brands)
        {
            if (!ModelState.IsValid)
            {
                return View(Brands);
            }
            _db.Brands.Add(Brands);
            await _db.SaveChangesAsync();

            //lưu ảnh
            string webRootPath = _iWebHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var BrandsFormDb = _db.Brands.Find(Brands.Id);


            if (files.Count != 0)
            {
                //up ảnh
                var uploads = Path.Combine(webRootPath, SD.BrandsImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, Brands.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                BrandsFormDb.Image = @"\" + SD.BrandsImageFolder + @"\" + Brands.Id + extension;
            }
            else
            {
                //nếu ko up ảnh thì đưa đến đường dẫn của ảnh mặc định
                var uploads = Path.Combine(webRootPath, SD.DefaultImageFolder + @"\" + SD.DefaultImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.BrandsImageFolder + @"\" + Brands.Id + ".png");
                BrandsFormDb.Image = @"\" + SD.BrandsImageFolder + @"\" + Brands.Id + ".png";
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        //GET : Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Brands = await _db.Brands.FindAsync(id);
            if (Brands == null)
            {
                return NotFound();
            }

            return View(Brands);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Brands Brands)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _iWebHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var BrandsFromDb = _db.Brands.Where(m => m.Id == Brands.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a Brand image
                    var uploads = Path.Combine(webRootPath, SD.BrandsImageFolder);
                    var extension_Brand = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(BrandsFromDb.Image);

                    if (System.IO.File.Exists(Path.Combine(uploads, Brands.Id + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, Brands.Id + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, Brands.Id + extension_Brand), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    Brands.Image = @"\" + SD.BrandsImageFolder + @"\" + Brands.Id + extension_Brand;
                }

                if (Brands.Image != null)
                {
                    BrandsFromDb.Image = Brands.Image;
                }

                BrandsFromDb.Name = Brands.Name;
                BrandsFromDb.isPublic = Brands.isPublic;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(Brands);
        }


        //GET : Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Brands = await _db.Brands.FindAsync(id);
            if (Brands == null)
            {
                return NotFound();
            }

            return View(Brands);
        }

        //GET : Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Brands = await _db.Brands.FindAsync(id);
            if (Brands == null)
            {
                return NotFound();
            }

            return View(Brands);
        }

        //POST : Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _iWebHostEnvironment.WebRootPath;
            Brands Brands = await _db.Brands.FindAsync(id);

            if (Brands == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, SD.BrandsImageFolder);
                var extension = Path.GetExtension(Brands.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, Brands.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, Brands.Id + extension));
                }
                _db.Brands.Remove(Brands);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
