using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class Feedbacks
    {
        public int Id { get; set; }

        [Display(Name = "Tên người phản hổi")]
        public string Name { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }
    }
}
