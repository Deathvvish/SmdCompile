using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmdCompileLib.Steam
{
    public class GameJsonData
    {
        public Data data = new Data();
    }
    public class Data
    {
        public string name { get; set; }
        public string type { get; set; }
        public int steam_appid { get; set; }
    }
}
