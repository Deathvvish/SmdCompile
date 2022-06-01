using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmdCompileLib.Model
{

    [Serializable]
    public struct Syntax
    {
        public string Foreground { get; set; }
        public string Background { get; set; }
        public string DriverOperation { get; set; }
        public bool IsRegex { get; set; }
        public string Keywords { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }


    public class SyntaxJson
    {
        public Dictionary<string, Syntax> syntax = new Dictionary<string, Syntax>();
        public string languages = "qc_";
        public Action<bool> EventOpen;
        public SyntaxJson()
        {

        }
        public void Save()
        {
            if (!Directory.Exists("Syntax"))
            {
                Directory.CreateDirectory("Syntax");

                File.WriteAllText(
                    _path_style(), 
                    System.Text.Encoding.Default.GetString(Properties.Resource1.qc_));
            }
            else
            {
               
                string json = JsonConvert.SerializeObject(syntax, Formatting.Indented);

                File.WriteAllText(_path_style(), json);
            }
                
        }
        private string _path_style()
        {
            return $"Syntax/{languages}.json";
        }
        public void Load()
        {
 
            
            if (File.Exists(_path_style()))
            {
                try
                {
                    string str_ = File.ReadAllText(_path_style());
                    syntax = JsonConvert.DeserializeObject<Dictionary<string, Syntax>>(str_);
                    if(EventOpen != null)
                        EventOpen(true);
                }
                catch (Exception)
                {
                    if (EventOpen != null)
                        EventOpen(false);
                }
            }
            else
            {
                Save();
            }

            
        }
        public void Clear()
        {
            syntax.Clear();
        }
        public void add(string color, Syntax Keywords)
        {
            syntax.Add(color, Keywords);
        }
    }
}
