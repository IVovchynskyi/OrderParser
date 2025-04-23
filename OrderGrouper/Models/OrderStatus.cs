using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderGrouper.Models
{
    internal enum OrderStatus
    {
        [Description("order status description: Unknown")]
        Unknown,
        [Description("order status description: Completed")]
        Completed,
        [Description("order status description: In Progress")]
        InProgress,
        [Description("order status description: Scheduled")]
        Scheduled,
        [Description("order status description: Cancelled")]
        Cancelled
    }
    
}

