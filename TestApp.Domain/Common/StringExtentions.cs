using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Common
{
    public static class StringExtentions
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
