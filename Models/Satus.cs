using System;
using System.Collections.Generic;

namespace PeTest.Models
{
    public partial class Satus
    {
        public Satus()
        {
            Product = new HashSet<Product>();
        }

        public string StatusId { get; set; }
        public string StatusName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
