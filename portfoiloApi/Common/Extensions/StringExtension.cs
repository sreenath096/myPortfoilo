using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfoiloApi.Common.Extensions
{
    public static class StringExtension
    {
        public static string ReplaceEmptyStringWithNull(this string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}