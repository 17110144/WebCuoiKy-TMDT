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

        [Display(Name = "Sales Person")]
        public string SalesPersonId { get; set; }

        [ForeignKey("SalesPersonId")]
        public virtual ApplicationUser SalesPerson { get; set; }

        public DateTime OrderDate { get; set; }

        [NotMapped]
        public DateTime OrderTime { get; set; }

        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }


        public bool isConfirmed { get; set; }


        [Display(Name = "Total Bill")]
        public double TotalBill { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
