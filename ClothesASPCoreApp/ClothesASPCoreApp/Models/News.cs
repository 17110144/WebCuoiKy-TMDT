using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [Display(Name = "Giảm")]
        public string Sale { get; set; }

        [Display(Name = "Ngày đăng")]
        public DateTime Date { get; set; }

        [Display(Name = "Công bố")]
        public bool isPublic { get; set; }
    }
}
