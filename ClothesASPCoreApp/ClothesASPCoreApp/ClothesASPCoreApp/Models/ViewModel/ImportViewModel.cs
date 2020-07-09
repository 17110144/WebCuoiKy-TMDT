using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models.ViewModel
{
    public class ImportViewModel
    {
        public IEnumerable<SpecialTags> SpecialTags { get; set; }
        public IEnumerable<ProductTypes> ProductTypes { get; set; }
        public IEnumerable<Vendors> Vendors { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }
}
