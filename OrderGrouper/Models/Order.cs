using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGrouper.Models
{
    internal class Order
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; }
        public string CompletionTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CancellationDate { get; set; }
    }
}
