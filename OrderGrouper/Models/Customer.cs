using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGrouper.Models
{
    internal class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalSpentAmount { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
