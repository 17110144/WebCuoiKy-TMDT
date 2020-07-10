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
        private int PageSize = 10;

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
                OrderVM.Orders = OrderVM.Orders.Where(a => a.Customers.Name.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.Customers.Email.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchPhone != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.Customers.PhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToList();
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

            var productList = (IEnumerable<Products>)(from p in _db.Products
                                                      join a in _db.OrderDetails
                                                      on p.Id equals a.ProductId
                                                      where a.OrderId == id
                                                      select p).Include("Vendors").Include("Brands");

            OrderDetailsViewModel objOrderVM = new OrderDetailsViewModel()
            {
                Orders = _db.Orders.Include(a => a.Customers).Include(a => a.OrderDetails).Include(a => a.SalesPerson)
                      .Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                Products = productList.ToList()
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
                ordersFormDb.Customers = objOrderVM.Orders.Customers;
                ordersFormDb.isConfirmed = objOrderVM.Orders.isConfirmed;
                if (User.IsInRole(SD.SuperAdminEndUser))
                {
                    ordersFormDb.SalesPersonId = objOrderVM.Orders.SalesPersonId;
                }

                /*---------------Trừ số lượng hàng khi Admin xác nhận----------------------*/
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
            var productList = (IEnumerable<Products>)(from p in _db.Products
                                                      join a in _db.OrderDetails
                                                      on p.Id equals a.ProductId
                                                      where a.OrderId == id
                                                      select p).Include("Vendors").Include("Brands");

            OrderDetailsViewModel objOrderVM = new OrderDetailsViewModel()
            {
                Orders = _db.Orders.Include(a => a.Customers).Include(a => a.OrderDetails).Include(a => a.SalesPerson)
                      .Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                Products = productList.ToList()
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
                Orders = _db.Orders.Include(o => o.Customers).Include(o => o.SalesPerson).Include(o => o.OrderDetails).Where(o => o.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                //OrderDetails = orderDetailsList.ToList()
            };

            return View(objOrderVM);

        }


        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _db.Orders.FindAsync(id);
            var customer = await _db.ApplicationUser.FindAsync(order.CustomerId);
            var tableOrderDetail = _db.OrderDetails.ToList();
            var tableProduct = _db.Products.ToList();
            foreach (var item in tableOrderDetail)
            {
                if (item.OrderId == order.Id)
                {
                    var orderdetail = await _db.OrderDetails.FindAsync(item.Id);
                    foreach (var product in tableProduct)
                    {
                        if (product.Id == orderdetail.ProductId)
                        {
                            int newQuantity = product.Quantity + orderdetail.OrderQuantity;
                            var productDB = await _db.Products.FindAsync(orderdetail.ProductId);
                            productDB.Quantity = newQuantity;
                            _db.Products.Update(productDB);
                        }
                    }
                    _db.OrderDetails.Remove(orderdetail);
                }
            }
            _db.ApplicationUser.Remove(customer);
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
