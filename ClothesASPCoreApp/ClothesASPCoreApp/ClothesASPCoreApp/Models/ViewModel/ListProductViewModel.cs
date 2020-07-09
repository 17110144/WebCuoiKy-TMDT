using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class ListProductViewModel
    {
        public List<Products> Products { get; set; }

        //Danh sách nội dung tìm kiếm
        public SelectList Category { get; set; }
        public SelectList ProductTypes { get; set; }
        public SelectList Brands { get; set; }
        public SelectList SpecialTags { get; set; }


        //Từ khóa tìm kiếm
        public string productBrand { get; set; }
        public string productCate { get; set; }
        public string productType { get; set; }
        public string productSTag { get; set; }

        public string SearchString { get; set; }
    }
}

