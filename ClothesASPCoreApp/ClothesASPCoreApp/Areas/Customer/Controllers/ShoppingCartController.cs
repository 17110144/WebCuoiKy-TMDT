using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesASPCoreApp.Data;
using ClothesASPCoreApp.Extensions;
using ClothesASPCoreApp.Models;
using ClothesASPCoreApp.Models.ViewModel;
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
            this._db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Products>()
            };
        }
        public async Task<IActionResult> Index(int id)
        {
            List<NumberOfProducts> lstShoppingCart = HttpContext.Session.Get<List<NumberOfProducts>>("ssShoppingCart");
            if (lstShoppingCart?.Count > 0)
            {
                foreach (NumberOfProducts cartItem in lstShoppingCart)
                {
                    Products prod = _db.Products.Include(p => p.Vendors).Include(p => p.Brands).Where(p => p.Id == cartItem.IdProduct).FirstOrDefault();

                    ShoppingCartVM.Products.Add(prod);
                }
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<NumberOfProducts> lstCartItems = HttpContext.Session.Get<List<NumberOfProducts>>("ssShoppingCart");

            ShoppingCartVM.Orders.OrderDate = DateTime.Now;

            Customers customer = ShoppingCartVM.Orders.Customers;
            _db.Customers.Add(customer);
            _db.SaveChanges();

            int idcustomer = customer.Id;

            Orders orders = ShoppingCartVM.Orders;
            orders.CustomerID = idcustomer;
            _db.Orders.Add(orders);
            _db.SaveChanges();

            int orderId = orders.Id;

            var ProductDB = _db.Products.ToList();

            foreach (NumberOfProducts item in lstCartItems)
            {
                OrderDetails orderItems = new OrderDetails()
                {
                    OrderId = orderId,
                    ProductId = item.IdProduct,
                    OrderQuantity = item.Quantity
                };
                for (int i = 0; i < ProductDB.Count(); i++)
                {
                    if (item.IdProduct == ProductDB[i].Id)
                    {
                        ProductDB[i].Quantity -= item.Quantity;
                        orderItems.OrderDetailsTotal = orderItems.OrderQuantity * ProductDB[i].Price;
                        break;
                    }
                }
                _db.SaveChanges();
                _db.OrderDetails.Add(orderItems);

            }
            _db.SaveChanges();
            lstCartItems = new List<NumberOfProducts>();
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);
            return RedirectToAction("OrderConfirmation", "ShoppingCart", new { Id = orderId });

        }


        public IActionResult Remove(int id)
        {
            List<NumberOfProducts> lstCartItems = HttpContext.Session.Get<List<NumberOfProducts>>("ssShoppingCart");

            if (lstCartItems.Count >= 0)
            {
                foreach (NumberOfProducts item in lstCartItems)
                {
                    if (item.IdProduct == id)
                    {
                        lstCartItems.Remove(item);
                        break;
                    }
                }

            }

            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }



        //Get
        public IActionResult OrderConfirmation(int id)
        {
            Orders orders = _db.Orders.Where(a => a.Id == id).FirstOrDefault();
            orders.Customers = _db.Customers.Where(a => a.Id == orders.CustomerID).FirstOrDefault();

            List<OrderDetails> orderDetails = _db.OrderDetails.Where(p => p.OrderId == id).ToList();
            List<Products> products = new List<Products>();
            foreach (OrderDetails o in orderDetails)
            {
                products.Add(_db.Products.Include(p => p.Vendors).Include(p => p.Brands).Where(p => p.Id == o.ProductId).FirstOrDefault());
            }

            OrderDetailsViewModel orderItemsVM = new OrderDetailsViewModel()
            {
                Orders = orders,
                Products = products
            };

            return View(orderItemsVM);
        }
    }
}