using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Extensions;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClothesASPCoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;

            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Products>(),
                Customer = new ApplicationUser(),
                Orders = new Orders()
            };
        }
        //Get Index Shopping Cart
        public async Task<IActionResult> Index()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart == null)
            {
                return View(ShoppingCartVM);
            }
            if (lstShoppingCart.Count > 0)
            {
                foreach (int cartItem in lstShoppingCart)
                {
                    Products prod = _db.Products.Include(p => p.SpecialTags).Include(p => p.Brands).Where(p => p.Id == cartItem).FirstOrDefault();
                    ShoppingCartVM.Products.Add(prod);
                }
            }
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                ApplicationUser customer = _db.ApplicationUser.Where(m => m.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                ShoppingCartVM.Customer = customer;
                ShoppingCartVM.Orders.OrderName = customer.Name;
                ShoppingCartVM.Orders.ShipAddress = customer.Address;
                ShoppingCartVM.Orders.OrderPhone = customer.PhoneNumber;
                ShoppingCartVM.Orders.OrderEmail = customer.Email;
            }
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            ShoppingCartVM.Orders.OrderDate = DateTime.Now;
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                ShoppingCartVM.Orders.CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
            }
            Orders Order = ShoppingCartVM.Orders;
            _db.Orders.Add(Order);
            _db.SaveChanges();

            int OrderId = Order.Id;

            for (int i = 0; i < lstCartItems.Count; i++)
            {
                OrderDetails OrderDetails = new OrderDetails()
                {
                    OrderId = OrderId,
                    ProductId = lstCartItems[i],
                    OrderQuantity = ShoppingCartVM.OrderDetails[i].OrderQuantity
                };
                _db.OrderDetails.Add(OrderDetails);

            }
            _db.SaveChanges();
            lstCartItems = new List<int>();
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);
            return RedirectToAction("OrderConfirmation", "ShoppingCart", new { Id = OrderId });
        }

        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }

        //Get
        public IActionResult OrderConfirmation(int id)
        {

            ShoppingCartVM.Orders = _db.Orders.Where(a => a.Id == id).FirstOrDefault();
            var orderDetailsList = (IEnumerable<OrderDetails>)(from od in _db.OrderDetails
                                                               join o in _db.Orders
                                                               on od.OrderId equals o.Id
                                                               where o.Id == id
                                                               select od).Include("Products");
            var ordersFormDb = _db.Orders.Where(a => a.Id == id).FirstOrDefault();
            ordersFormDb.TotalBill = 0;
            foreach (var item in orderDetailsList)
            {
                ordersFormDb.TotalBill += item.Products.Price * item.OrderQuantity;
            }
            ShoppingCartVM.OrderDetails = orderDetailsList.ToList();
            _db.SaveChanges();
            return View(ShoppingCartVM);
        }
    }
}