using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class ProductsViewModel
    {
        public Products Products { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<Vendors> Vendors { get; set; }
        public IEnumerable<SpecialTags> SpecialTags{ get; set; }
      
    }
}
