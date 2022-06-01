using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmdCompileLib.Model
{
    public class MReplace
    {
        public string DATA = "";
        public string Replace(string r , object rr)
        {
            return DATA = DATA.Replace(r, rr.ToString());
        }
        public string Replace(string r)
        {
            return Replace(r, "");
        }
    }
}
