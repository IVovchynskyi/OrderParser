using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderGrouper.Models
{
    internal class InputOrder
    {
        public string CustomerFullName { get; set; }
        public string OrderItemName { get; set; }
        public string OrderDate { get; set; }
        public string OrderEndDate { get; set; }
        public string CancellationDate { get; set; }
        public decimal Cost { get; set; }

    }


}
