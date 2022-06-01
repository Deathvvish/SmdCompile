using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmdCompileLib.Model
{
    public static class CRegex
    {
        public static string GetString(this string keyName, string valueName)
        {
            string str_ = "";
            foreach (Match item in Regex.Matches(keyName , valueName))
            {
                str_ += item.Value;
            }
            return str_;
        }
    }
}
