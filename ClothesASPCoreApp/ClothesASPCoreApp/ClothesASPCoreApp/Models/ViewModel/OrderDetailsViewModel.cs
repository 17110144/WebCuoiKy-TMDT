using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class OrderDetailsViewModel
    {
        public Orders Orders { get; set; }
        public List<ApplicationUser> SalesPerson { get; set; }
        public List<Products> Products { get; set; }

        //List này dùng để truy xuất số lượng sản phẩm của đơn hàng.
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
