using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên loại sản phẩm")]
        public string Name { get; set; }
    }
}
