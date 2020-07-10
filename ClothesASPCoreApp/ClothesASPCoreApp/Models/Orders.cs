using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class Orders
    {
        public int Id { get; set; }

        [Display(Name = "Người bán")]
        public string SalesPersonId { get; set; }

        [ForeignKey("SalesPersonId")]
        public virtual ApplicationUser SalesPerson { get; set; }

        [Display(Name = "Người mua")]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual ApplicationUser Customers { get; set; }


        [Display(Name = "Ngày đặt")]
        public DateTime OrderDate { get; set; }

        [NotMapped]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Địa chỉ nhận hàng")]
        public string Address { get; set; }


        [Display(Name = "Trạng thái")]
        public bool isConfirmed { get; set; }


        [Display(Name = "Tổng đơn hàng")]
        public double TotalBill { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
