using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
using ClothesASPCoreApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private int PageSize = 4;

        public OrdersController(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index(int productPage = 1, string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null)
        {
            ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrdersViewModel OrderVM = new OrdersViewModel()
            {
                Orders = new List<Orders>()
            };

            StringBuilder param = new StringBuilder();

            param.Append("/Admin/Orders?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }
            param.Append("&searchDate=");
            if (searchDate != null)
            {
                param.Append(searchDate);
            }


            OrderVM.Orders = _db.Orders.Include(a => a.SalesPerson).ToList();
            if (User.IsInRole(SD.AdminEndUser))
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.SalesPersonId == claim.Value).ToList();
            }

            if (searchName != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.CustomerName.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.CustomerEmail.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchPhone != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.CustomerPhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToList();
            }
            if (searchDate != null)
            {
                try
                {
                    DateTime appDate = Convert.ToDateTime(searchDate);
                    OrderVM.Orders = OrderVM.Orders.Where(a => a.OrderDate.ToShortDateString().Equals(appDate.ToShortDateString())).ToList();
                }
                catch (Exception ex)
                {

                }

            }

            var count = OrderVM.Orders.Count;

            OrderVM.Orders = OrderVM.Orders.OrderBy(p => p.OrderDate)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize).ToList();


            OrderVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };


            return View(OrderVM);
        }

        //GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailsList = (IEnumerable<OrderDetails>)(from od in _db.OrderDetails
                                                               join o in _db.Orders
                                                               on od.OrderId equals o.Id
                                                               where o.Id == id
                                                               select od).Include("Products");

            OrderDetailsViewModel objOrderVM = new OrderDetailsViewModel()
            {
                Orders = _db.Orders.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                OrderDetails = orderDetailsList.ToList()

            };
            return View(objOrderVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderDetailsViewModel objOrderVM)
        {
                   
            if (ModelState.IsValid)
            {
                var ordersFormDb = _db.Orders.Where(a => a.Id == objOrderVM.Orders.Id).FirstOrDefault();
                ordersFormDb.CustomerName = objOrderVM.Orders.CustomerName;
                ordersFormDb.CustomerEmail = objOrderVM.Orders.CustomerEmail;
                ordersFormDb.CustomerPhoneNumber = objOrderVM.Orders.CustomerPhoneNumber;
                ordersFormDb.isConfirmed = objOrderVM.Orders.isConfirmed;
                if (User.IsInRole(SD.SuperAdminEndUser))
                {
                    ordersFormDb.SalesPersonId = objOrderVM.Orders.SalesPersonId;
                }
                /*-TH1--------------Trừ số lượng hàng khi Admin xác nhận----------------------*/
                //Với project này chúng em dùng TH2 đó là trừ số lượng hàng trong kho ngay khi khách hàng tiến hành nhấn đặt hàng.
                //Và để thuộc tính isConfirmed này để xác nhận giao hàng  (hướng phát triển)
                //if (ordersFormDb.isConfirmed == true)
                //{
                //    var productsList = _db.Products.ToList();
                //    foreach (var item in orderDetailsList)
                //    {
                //        for (int j = 0; j < productsList.Count; j++)
                //        {
                //            if (item.ProductId == productsList[j].Id)
                //            {
                //                productsList[j].Quantity -= item.OrderQuantity;
                //            }
                //        }
                //    }
                //}
                /*-----------------------------------------------------------------------*/

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(objOrderVM);
        }


        //GET Detials
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Phần làm thêm_Phan Đình Hoàng
            //Tạo một danh sách với LINQ để tìm ra danh sách đơn đặt hàng chi tiết ứng mới mỗi id được truyền vào khi nhấn Details
            var orderDetailsList = (IEnumerable<OrderDetails>)(from p in _db.OrderDetails
                                                               join a in _db.Orders
                                                               on p.OrderId equals a.Id
                                                               where a.Id == id
                                                               select p).Include("Products");

            OrderDetailsViewModel objOrderVM = new OrderDetailsViewModel()
            {
                Orders = _db.Orders.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                OrderDetails = orderDetailsList.ToList()
            };

            return View(objOrderVM);

        }


        //GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Tương tự như Detail
            var orderDetailsList = (IEnumerable<OrderDetails>)(from p in _db.OrderDetails
                                                               join a in _db.Orders
                                                               on p.OrderId equals a.Id
                                                               where a.Id == id
                                                               select p).Include("Products");

            OrderDetailsViewModel objOrderVM = new OrderDetailsViewModel()
            {
                Orders = _db.Orders.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                OrderDetails = orderDetailsList.ToList()
            };

            return View(objOrderVM);

        }


        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Order = await _db.Orders.FindAsync(id);
            //Phần làm thêm_Phan Đình Hoàng
            //Khi xóa đơn hàng thì số lượng sản phẩm sẽ được hoàn trả  về lại kho hàng của shop
            var orderDetailsList = (IEnumerable<OrderDetails>)(from od in _db.OrderDetails
                                                               join o in _db.Orders
                                                               on od.OrderId equals o.Id
                                                               where o.Id == id
                                                               select od).Include("Products");
            var productsList = _db.Products.ToList();
            foreach (var item in orderDetailsList)
            {
                for (int j = 0; j < productsList.Count(); j++)
                {
                    if (item.ProductId == productsList[j].Id)
                    {
                        productsList[j].Quantity += item.OrderQuantity;
                    }
                }
            }
            _db.Orders.Remove(Order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
