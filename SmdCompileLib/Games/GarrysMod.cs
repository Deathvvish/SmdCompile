using System;
using System.IO;

namespace SmdCompileLib.Games
{
    public class GarrysMod : GameBase
    {

        public GarrysMod(string path)
        {
            if(Directory.Exists(path))
                this.PathGame = path;
        }
        
        public override void UpdatePathes()
        {
            this.Files.Add("exe", Path.Combine(this.PathGame , "hl2.exe"));
            string path_bin = Path.Combine(this.PathGame , "bin");
            this.Files.Add("gmpublish", Path.Combine(path_bin, "gmpublish.exe"));
            this.Files.Add("studiomdl", Path.Combine(path_bin, "studiomdl.exe"));
            this.Files.Add("hammer", Path.Combine(path_bin, "hammer.exe"));

            ///////////////////////////////////////////////////////////////////////
            ///////////////////////ЖРАТЬЬЬьЬ!//////////////////////////////////////
            ////////////////////////////////Хачу Кушать!///////////////////////////


            string garrysmod = Path.Combine(this.PathGame, "garrysmod");
            this.Directories.Add("models", Path.Combine(garrysmod, "models"));
            this.Directories.Add("maps", Path.Combine(garrysmod, "maps"));
            this.Directories.Add("lua", Path.Combine(garrysmod, "lua"));







        }     
    }
}
