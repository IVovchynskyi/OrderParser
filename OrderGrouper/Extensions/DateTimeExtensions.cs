using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGrouper.Extensions
{
    internal static class DateTimeExtensions
    {
        public static string ToOrderDate(this DateTime d)
        { 
            return d.ToString("yyyy-MM-dd"); 
        }
    }
}
