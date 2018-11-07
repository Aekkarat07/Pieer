using System;
using System.Collections.Generic;

namespace PeTest.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public string UnitCode { get; set; }
        public string NameUnit { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
