
using Newtonsoft.Json;
using SmdCompileLib.Data;
using SmdCompileLib.Games;
using SmdCompileLib.Model;
using SmdCompileLib.Steam;
using SmdCompileLib.Sys;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;


namespace SmdCompile.TestConsole
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            #region Process Test
            //Process process = new Process();
            //process.FileName = @"C:\Users\UnderKo\source\repos\SmdCompile\ConsoleApp1\bin\Debug\ConsoleApp1.exe";
            //process.EventDataReceivedHandler += (o, e) =>
            //{
            //    Console.WriteLine(e.Data);
            //};
            //process.Start(); 
            #endregion
            #region WFTimer
            //WFTimer wFTimer = new WFTimer();
            //wFTimer.EventTimer += (time) =>
            //{
            //    Console.WriteLine("asd");
            //};
            //wFTimer.Start();
            #endregion
            #region ThreadTimer
            //ThreadTimer threadTimer = new ThreadTimer(null);
            //threadTimer.Tick += (o, e) =>
            //{
            //    Console.WriteLine("asd");
            //};
            //threadTimer.initialize(); 
            #endregion
            #region JsonSetting
            //JsonSetting jsonSetting = new JsonSetting();
            //jsonSetting.Message += (str) =>
            //{
            //    Console.WriteLine(str);
            //};
            //jsonSetting.Error += (str) =>
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine(str);
            //};
            //jsonSetting.Load();
            //jsonSetting.Save();
            #endregion
            #region SmdCompileLib.Model.WebClient
            //using (var client = new SmdCompileLib.Model.WebClient())
            //{

            //    Console.WriteLine((int)client.StatusCode());
            //    try
            //    {
            //        string Content = client.DownloadString($"https://i.imgur.com/i6OUWhj.png");
            //        Console.WriteLine(Content);
            //    }
            //    catch (Exception)
            //    {

            //        Console.WriteLine((int)client.StatusCode());
            //    }

            //}
            #endregion
            #region SteamGames
            //SteamGames steamGames = new SteamGames();
            //GameJsonData gameJsonData = steamGames.GetGame(4000);
            //Console.WriteLine(gameJsonData.data.name);
            #endregion
            #region GarrysMod
            //GarrysMod garrysMod = new GarrysMod(@"E:\Steam\steamapps\common\GarrysMod");
            //garrysMod.UpdatePathes();
            ////garrysMod.DebugFiles();

            //Console.WriteLine(garrysMod.IsValidFDGames());

            #endregion
            #region file find
            //FileFInder.Find(
            //    @"E:\Steam\steamapps\common\wallpaper_engine", 
            //    "locales", 
            //    FileFInder.EnumFD.DIR);
            //string f = FileFInder.f_find_dir(@"E:\Steam\steamapps\common\wallpaper_engine", "locales");
            //Console.WriteLine(f); 
            #endregion
            #region InstallsApp
            //InstallsApp installsApp = new InstallsApp();
            //foreach (var item in installsApp.GetInstallsApp())
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine($"{item.InstallPath}");
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine($"=>{item.RegistryKey}");
            //} 
            #endregion
            #region FileFInder
            //FileFInder fileFInder = new FileFInder();
            //fileFInder.LocalPath = @"E:\Steam\steamapps\common\GarrysMod\garrysmod\data";
            //fileFInder.RegexPattern = "[\\s\\S]+?t.txt";
            //fileFInder.max_count = 20;
            //Console.WriteLine(string.Join(" " , fileFInder.FindArray())); 
            #endregion

            #region SyntaxJson
            //SyntaxJson syntaxJson = new SyntaxJson();
            //syntaxJson.Load();
            //syntaxJson.add("#4DC6AD", new Syntax()
            //{
            //    IsRegex = true,
            //    Foreground = "#4D4D4D",
            //});
            //syntaxJson.Save();
            #endregion

            Console.ReadLine();
        }
    }
}
