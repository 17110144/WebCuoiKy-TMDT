using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<Products> Products { get; set; }
        public List<SpecialTags> SpecialTags { get; set; }
        public List<News> News { get; set; }
    }
}
