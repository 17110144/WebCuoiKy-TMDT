using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClothesASPCoreApp.Models
{
    public class Brands
    {
        public int Id { get; set; }

        [Display(Name = "Tên thương hiệu")]
        [Required(ErrorMessage = "Vui lòng điền tên nhãn hiệu!")]
        public string Name { get; set; }
    }
}
