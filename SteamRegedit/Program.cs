using Microsoft.Win32;
using SmdCompileLib.Steam;
using SmdCompileLib.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace SteamRegedit
{

    internal class Program
    {
        static SteamAccount steamAccount = new SteamAccount();


        static InstallsApp installsApp = new InstallsApp();





        static void Main(string[] args)
        {
            PlatformID os_platform = System.Environment.OSVersion.Platform;
            if (os_platform != PlatformID.Win32NT)
            {
                Console.WriteLine($"{os_platform.ToString()}");
                return;
            }
            if (args.Length == 0)
            {
                while (true)
                {
                    string str_arg = Console.ReadLine().ToLower();

                    switch (str_arg)
                    {
                        case "steam":
                            Console.WriteLine(steamAccount.ToString());
                            break;
                        case "getapps":

                            installsApp.ErrorLog += (o) =>
                            {
                                //Console.WriteLine(o);
                            };


                            foreach (var item in installsApp.GetInstallsApp())
                            {
                                Console.WriteLine(item);
                            }

                            break;
                        default:
                            break;
                    }

                }
            }
        }
    }
}
