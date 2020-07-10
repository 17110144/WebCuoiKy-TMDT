using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesASPCoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerOdersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerOdersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Orders> lsOderOfCustomer = new List<Orders>();
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                lsOderOfCustomer = _db.Orders.Where(m => m.CustomerId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            }
            return View(lsOderOfCustomer);
        }
        //GET Detials
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Tạo một danh sách với LINQ để tìm ra danh sách đơn đặt hàng chi tiết ứng mới mỗi id được truyền vào khi nhấn Details
            var orderDetailsList = (IEnumerable<OrderDetails>)(from p in _db.OrderDetails
                                                               join a in _db.Orders
                                                               on p.OrderId equals a.Id
                                                               where a.Id == id
                                                               select p).Include("Products");

            ShoppingCartViewModel ShoppingCartVM = new ShoppingCartViewModel()
            {
                Orders = _db.Orders.Where(a => a.Id == id).FirstOrDefault(),
                OrderDetails = orderDetailsList.ToList()
            };
            return View(ShoppingCartVM);
        }
        //GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderDetailsList = (IEnumerable<OrderDetails>)(from p in _db.OrderDetails
                                                               join a in _db.Orders
                                                               on p.OrderId equals a.Id
                                                               where a.Id == id
                                                               select p).Include("Products");

            ShoppingCartViewModel ShoppingCartVM = new ShoppingCartViewModel()
            {
                Orders = _db.Orders.Where(a => a.Id == id).FirstOrDefault(),
                OrderDetails = orderDetailsList.ToList()
            };
            return View(ShoppingCartVM);

        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Order = await _db.Orders.FindAsync(id);
            _db.Orders.Remove(Order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}