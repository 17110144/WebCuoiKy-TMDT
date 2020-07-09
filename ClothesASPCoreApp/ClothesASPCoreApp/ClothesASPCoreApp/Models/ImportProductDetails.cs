using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesASPCoreApp.Models
{
    public class ImportProductDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Phải có thông tin ngày nhập hàng!")]
        [Display(Name = "Ngày nhập")]
        public DateTime DateImport { get; set; }

        [Display(Name = "Số lượng nhập")]
        public int AmountProduct { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }
    }
}
