using SmdCompileLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmdCompileLib.Steam
{
    public class SteamGames : EventLog
    {
        public GameJsonData GetGame(int id)
        {
            GameJsonData obj = new GameJsonData();
            SmdCompileLib.Steam.SteamWebApi steamWebApi = new SmdCompileLib.Steam.SteamWebApi()
            {
                GMAE_ID = id,
                // URL_ = "http://asdasd" // test
            };
            steamWebApi.Get();
            try
            {
                string json_data_ = "{" + Regex.Match(steamWebApi.Content, "\"data\":[\\s\\S]+?steam_appid\":[0-9]+", RegexOptions.Multiline).Value + "}}";
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<GameJsonData>(json_data_);
            }
            catch (Exception e) 
            {
                f_ErrorLog(e.Message);
            }
            return obj;
        }
    
    }
}
