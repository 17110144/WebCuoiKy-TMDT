using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class OrdersViewModel
    {
        public List<Orders> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
