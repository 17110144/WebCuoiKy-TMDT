using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public string Vendor { get; set; }

        public DateTime Update { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Categories Categories { get; set; }

        [Display(Name = "Special Tag")]
        public int SpecialTagID { get; set; }
        [ForeignKey("SpecialTagID")]
        public virtual SpecialTags SpecialTags { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
