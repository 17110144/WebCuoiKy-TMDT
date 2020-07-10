using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Products> Products { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public Orders Orders { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
