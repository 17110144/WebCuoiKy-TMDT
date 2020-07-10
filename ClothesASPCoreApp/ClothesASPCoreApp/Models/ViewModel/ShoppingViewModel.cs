using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class ShoppingViewModel
    {
        public List<Products> Products { get; set; }
        public List<Brands> Brands { get; set; }
        public List<Categories> Categories { get; set; }
        public List<ProductTypes> ProductTypes { get; set; }
        public List<SpecialTags> SpecialTags { get; set; }
    }
}
