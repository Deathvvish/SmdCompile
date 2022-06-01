using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace SmdCompileLib.Steam
{
    public class SteamWebApi
    {
        public int GMAE_ID = -1; // gmod 
        // https://store.steampowered.com/api/appdetails/?appids=4000

        public string URL_ = "https://store.steampowered.com/api/appdetails/?appids=";

        public Action<string> ActionDownloadString;
        public string Content
        {
            get;set;
        }
        public SteamWebApi()
        {
             
        }

        public void Get()
        {
            if (GMAE_ID == -1)
                return;
            using (var client = new SmdCompileLib.Model.WebClient())
            {
                try
                {
                   
                    Content = client.DownloadString($"{URL_}{GMAE_ID}");

                    
                    if(ActionDownloadString != null && client.StatusCode() == HttpStatusCode.OK)
                        this.ActionDownloadString(Content);

                    //Newtonsoft.Json.JsonConvert.DeserializeObject<Setting>(read_file_);

                }
                catch (Exception)
                {

                      
                }
               
            }
        }
    }

}
