using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmdCompileLib.Games
{
    public class GameBase
    {
        public Dictionary<string, string> Files = new Dictionary<string, string>();
        public Dictionary<string, string> Directories = new Dictionary<string, string>();
        public string PathGame
        {
            get; set;
        }

        public virtual void UpdatePathes()
        {
            this.Files.Add("exe", Path.Combine(this.PathGame, "hl2.exe"));
            string path_bin = Path.Combine(this.PathGame, "bin");
        }
        public virtual bool IsValidFDGames()
        {

            foreach (var item in this.Files)
            {
                if(File.Exists(item.Value) == false)
                    return false;
            }
            foreach (var item in this.Directories)
            {
                if (Directory.Exists(item.Value) == false)
                    return false;
            }
            return true;
        }
        public virtual void DebugFiles()
        {
            Console.WriteLine("Files:");
            foreach (var item in this.Files)
            {
                Console.WriteLine($"[{item.Key}][{item.Value}][{File.Exists(item.Value)}]");
            }
            Console.WriteLine("Directories:");
            foreach (var item in this.Directories)
            {
                Console.WriteLine($"[{item.Key}][{item.Value}][{Directory.Exists(item.Value)}]");
            }

        }
    }
}

