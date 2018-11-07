using System;
using System.Collections.Generic;

namespace PeTest.Models
{
    public partial class Catategory
    {
        public Catategory()
        {
            Product = new HashSet<Product>();
        }

        public string CatId { get; set; }
        public string NameCat { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
