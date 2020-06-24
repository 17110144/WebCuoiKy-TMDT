using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _iWebHostEnvironment;


        public NewsController(ApplicationDbContext db, IWebHostEnvironment iWebHostEnvironment)
        {
            _db = db;
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        //Bất kỳ ai cũng có thể xem được trang Index của New bao gồm cả khách hàng
        public IActionResult Index()
        {
            return View(_db.News.ToList());
        }

       
        //Thêm ràng buộc phân quyền cho SuperAdmin và Admin, chỉ có 2 người dùng này mới được thêm xóa sửa các nội dung tin tức của Web    
        //GET Create Action Method
        [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
        public IActionResult Create()
        {
            return View();
        }
        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
        public async Task<IActionResult> Create(News News)
        {
            if (!ModelState.IsValid)
            {
                return View(News);
            }
            News.Date = DateTime.Now;
            _db.News.Add(News);
            await _db.SaveChangesAsync();

            //lưu ảnh
            string webRootPath = _iWebHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var newsFormDb = _db.News.Find(News.Id);


            if (files.Count != 0)
            {
                //up ảnh
                var uploads = Path.Combine(webRootPath, SD.NewsImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, News.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                newsFormDb.Image = @"\" + SD.NewsImageFolder + @"\" + News.Id + extension;
            }
            else
            {
                //nếu ko up ảnh thì đưa đến đường dẫn của ảnh mặc định
                var uploads = Path.Combine(webRootPath, SD.DefaultImageFolder + @"\" + SD.DefaultImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.NewsImageFolder + @"\" + News.Id + ".png");
                newsFormDb.Image = @"\" + SD.NewsImageFolder + @"\" + News.Id + ".png";
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        //GET : Edit
        [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _db.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
        public async Task<IActionResult> Edit(int id, News news)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _iWebHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var newsFromDb = _db.News.Where(m => m.Id == news.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, SD.NewsImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(newsFromDb.Image);

                    if (System.IO.File.Exists(Path.Combine(uploads, news.Id + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, news.Id + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, news.Id + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    news.Image = @"\" + SD.NewsImageFolder + @"\" + news.Id + extension_new;
                }

                if (news.Image != null)
                {
                    newsFromDb.Image = news.Image;
                }

                newsFromDb.Title = news.Title;
                newsFromDb.Content = news.Content;
                newsFromDb.Date = news.Date;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(news);
        }


        //GET : Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _db.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        //GET : Delete
        [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _db.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        //POST : Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _iWebHostEnvironment.WebRootPath;
            News news = await _db.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, SD.NewsImageFolder);
                var extension = Path.GetExtension(news.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, news.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, news.Id + extension));
                }
                _db.News.Remove(news);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
