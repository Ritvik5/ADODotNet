using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODotNetCustomerOrder
{
    public class Customer
    {
        public int Customer_Id { get; set; } 
        public string Customer_Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public decimal Salary { get; set; }
    }
}
