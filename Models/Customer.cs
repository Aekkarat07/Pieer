using System;
using System.Collections.Generic;

namespace PeTest.Models
{
    public partial class Customer
    {
        public string CustId { get; set; }
        public string InitialCode { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string CustType { get; set; }

        public Type CustTypeNavigation { get; set; }
        public Title InitialCodeNavigation { get; set; }
    }
}
