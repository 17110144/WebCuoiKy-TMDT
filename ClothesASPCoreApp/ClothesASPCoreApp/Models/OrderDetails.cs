using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Orders Orders { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int OrderQuantity { get; set; }
    }
}
