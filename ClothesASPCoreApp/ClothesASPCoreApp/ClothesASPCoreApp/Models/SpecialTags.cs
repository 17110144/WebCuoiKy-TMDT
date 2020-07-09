using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClothesASPCoreApp.Models
{
    public class SpecialTags
    {
        public int Id { get; set; }

        [Display(Name = "Tên nhãn đặc biệt")]
        [Required]
        public string Name { get; set; }
    }
}
