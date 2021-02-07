using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDesktop.Models.Extensions
{
    public static class Extensions
    {
        public static string AddSpaceBeforeCaps(this Enum str) => string.Concat(str.ToString().Select(x => char.IsUpper(x) || char.IsNumber(x) ? " " + x : x.ToString())).TrimStart(' ');
    }
}
