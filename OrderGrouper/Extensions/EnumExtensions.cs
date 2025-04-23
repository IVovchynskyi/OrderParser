using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderGrouper.Extensions
{
     internal static class EnumExtensions
    {
        public static string GetDescription(this Enum myEnum)
        {
            var result = myEnum.ToString();
            if (myEnum == null)
            {
                return result;
            }

            var f_info = myEnum.GetType().GetField(myEnum.ToString());
            if (f_info != null && Attribute.IsDefined(f_info, typeof(DescriptionAttribute)))
            {
                var my_attr = (DescriptionAttribute?)Attribute.GetCustomAttribute(f_info, typeof(DescriptionAttribute));
                result = my_attr?.Description ?? result;
            }

            return result;
        }
    }
}
