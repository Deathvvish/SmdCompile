using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmdCompileLib.Model
{
    public class Reg
    {
        public static string GetValue(string keyName, string valueName)
        {

            object o = Microsoft.Win32.Registry.GetValue(keyName, valueName, null);
            return o == null ? "NULL" : o.ToString();
        }
       
    }
}
