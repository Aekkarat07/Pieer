using System;
using System.Collections.Generic;

namespace PeTest.Models
{
    public partial class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public double? UnitPerPrice { get; set; }
        public string Qty { get; set; }
        public string StatusId { get; set; }
        public string UnitCode { get; set; }
        public string CatId { get; set; }

        public Catategory Cat { get; set; }
        public Satus Status { get; set; }
        public Unit UnitCodeNavigation { get; set; }
    }
}
