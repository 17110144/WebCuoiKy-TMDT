using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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

        [AllowNull]
        [Display(Name = "Người mua")]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser Customers { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime OrderDate { get; set; }
        [NotMapped]
        [Display(Name = "Thời gian đặt")]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Tên người nhận hàng")]
        public string OrderName { get; set; }

        [Display(Name = "Địa chỉ nhận hàng")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhận hàng!")]
        public string ShipAddress { get; set; }

        [Display(Name = "SĐT nhận hàng")]
        [Required(ErrorMessage = "Vui lòng nhập SĐT người nhận hàng")]
        public string OrderPhone { get; set; }

        [Display(Name = "Email nhận hàng")]
        [Required(ErrorMessage = "Vui lòng nhập Email người nhận hàng")]
        public string OrderEmail { get; set; }

        [Display(Name = "Tổng đơn hàng")]
        public double TotalBill { get; set; }

        [Display(Name = "Trạng thái")]
        public bool isConfirmed { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
