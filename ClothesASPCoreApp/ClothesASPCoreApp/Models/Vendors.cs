using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClothesASPCoreApp.Models
{
    public class Vendors
    {
        public int Id { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên nhà cung cấp!")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhà cung cấp!")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập SĐT liên hệ của nhà cung cấp!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Hãy mô tả gì đó!")]
        public string Description { get; set; }
    }
}
