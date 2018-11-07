using System;
using System.Collections.Generic;

namespace PeTest.Models
{
    public partial class Title
    {
        public Title()
        {
            Customer = new HashSet<Customer>();
        }

        public string InitialCode { get; set; }
        public string InitialName { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
