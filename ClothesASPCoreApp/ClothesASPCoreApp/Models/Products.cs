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

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime Update { get; set; }

        [Display(Name = "Đơn giá")]
        public double Price { get; set; }

        [Display(Name = "Số lượng tồn kho")]
        public int Quantity { get; set; }

        public string Image { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        public virtual Vendors Vendors { get; set; }

        [Display(Name = "Thương hiệu")]
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brands Brands { get; set; }

        [Display(Name = "Danh mục")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Categories Categories { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int ProductTypeID { get; set; }
        [ForeignKey("ProductTypeID")]
        public virtual ProductTypes ProductTypes { get; set; }

        [Display(Name = "Tên thẻ")]
        public int SpecialTagID { get; set; }
        [ForeignKey("SpecialTagID")]
        public virtual SpecialTags SpecialTags { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }


        [Display(Name = "Công cố sản phẩm")]
        public bool isPublic { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
