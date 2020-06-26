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
        public SelectList Category { get; set; }
        public SelectList Vendor { get; set; }
        public SelectList SpecialTags { get; set; }
        public string ProductCate { get; set; }
        public string ProductTag { get; set; }
        public string SearchString { get; set; }
    }
}

