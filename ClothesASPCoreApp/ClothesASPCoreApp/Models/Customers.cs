using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Ngày sinh")]
        public string DOB { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "SĐT liên hệ")]
        public string PhoneNumber { get; set; }

    }
}
