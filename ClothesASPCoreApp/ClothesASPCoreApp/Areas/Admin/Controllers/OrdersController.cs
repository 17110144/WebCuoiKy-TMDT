using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
using ClothesASPCoreApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;

namespace ClothesASPCoreApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private int PageSize = 10;

        public OrdersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult RequestChangePassword()
        {
            return View();
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null)
        {
            ApplicationUser Admin = _db.ApplicationUser.Where(m => m.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            if (Admin.isLockRole == true)
            {
                return RedirectToAction("RequestChangePassword", "Orders");
            }

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
                OrderVM.Orders = OrderVM.Orders.Where(a => a.OrderName.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.OrderEmail.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchPhone != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.OrderPhone.ToLower().Contains(searchPhone.ToLower())).ToList();
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
                SalesPerson = _db.ApplicationUser.Where(m => m.EmailConfirmed == true).Where(m => m.isLockRole == false).Where(m=>m.Role==SD.AdminEndUser).ToList(),
                OrderDetails = orderDetailsList.ToList()

            };
            return View(objOrderVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderDetailsViewModel objOrderVM)
        {
            var orderDetailsList = (IEnumerable<OrderDetails>)(from od in _db.OrderDetails
                                                               join o in _db.Orders
                                                               on od.OrderId equals o.Id
                                                               where o.Id == id
                                                               select od).Include("Products");
            if (ModelState.IsValid)
            {
                var ordersFormDb = _db.Orders.Where(a => a.Id == objOrderVM.Orders.Id).FirstOrDefault();
                ordersFormDb.isConfirmed = objOrderVM.Orders.isConfirmed;
                if (User.IsInRole(SD.SuperAdminEndUser))
                {
                    ordersFormDb.SalesPersonId = objOrderVM.Orders.SalesPersonId;
                }
                /*--------------Trừ số lượng hàng khi Nhân viên bán hàng bấm xác nhận----------------------*/
                if (ordersFormDb.isConfirmed == true)
                {
                    var productsList = _db.Products.ToList();
                    foreach (var item in orderDetailsList)
                    {
                        for (int j = 0; j < productsList.Count; j++)
                        {
                            if (item.ProductId == productsList[j].Id)
                            {
                                productsList[j].Quantity -= item.OrderQuantity;
                            }
                        }
                    }
                    //Gửi mail tới hòm thư của khách hàng để thông báo đơn hàng đã được vận chuyển
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("ShopSaler", "vohoang17110143@gmail.com"));
                        message.To.Add(new MailboxAddress("Not Reply", objOrderVM.Orders.OrderEmail));
                        message.Subject = "Confirm your email to join us";
                        message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
                        {
                            Text = "Đơn hàng của bạn đặt ở trang ClothesShop đã được chuyển đến đơn vị giao hàng. Hãy đảm bảo nhận được cuộc gọi của Shipper trong vòng 10 tiếng tới!"
                        };
                        client.Connect("smtp.gmail.com", 465, true);
                        client.Authenticate("vohoang17110143@gmail.com", "bainao1999");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
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
            _db.Orders.Remove(Order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}