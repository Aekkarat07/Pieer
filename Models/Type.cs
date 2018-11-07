using System;
using System.Collections.Generic;

namespace PeTest.Models
{
    public partial class Type
    {
        public Type()
        {
            Customer = new HashSet<Customer>();
        }

        public string CustType { get; set; }
        public string NameType { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
