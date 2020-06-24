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
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Products>()
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
                    Products prod = _db.Products.Include(p => p.SpecialTags).Include(p => p.Categories).Where(p => p.Id == cartItem).FirstOrDefault();
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
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            ShoppingCartVM.Orders.OrderDate = DateTime.Now;

            Orders Orders = ShoppingCartVM.Orders;
            _db.Orders.Add(Orders);
            _db.SaveChanges();

            int OrderId = Orders.Id;

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


        //Phần Làm Thêm_Phan Đình Hoàng_Quản lý số lượng đơn đặt hàng và Số lượng hàng trong kho
        //Khi khách nhấn vào đặt hàng thì kho hàng sẽ trừ số lượng sản phẩm tương ứng
        //các View để đưa ra thông tin chi tiết về sản phẩm sẽ khác đi rất nhiều so với bài DEMO cụ thể là view _OrderProductDetails view này sẽ đưa ra thông tin số lượng của từng sảm phẩm đã đặt
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

            /*-TH2--------------------Trừ số lượng hàng khi khách đặt hàng-------------------------*/
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
            /*--------------------------------------------------------------------------------*/

            _db.SaveChanges();
            return View(ShoppingCartVM);
        }
    }
}
