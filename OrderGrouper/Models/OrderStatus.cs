using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGrouper.Models
{
    internal enum OrderStatus
    {
        Unknown,
        Completed,
        InProgress,
        Scheduled,
        Cancelled
    }
}
