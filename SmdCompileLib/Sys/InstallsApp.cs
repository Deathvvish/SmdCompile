using Microsoft.Win32;
using SmdCompileLib.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmdCompileLib.Sys
{
    public class AppInf
    {
        public string Name
        {
            get;set;
        }
        public string InstallPath
        {
            get;set;
        }
        public string RegistryKey
        {
            get; set;
        }
        public override string ToString()
        {
            return $"{Name} => {InstallPath}";
        }
    }
    public class InstallsApp : EventLog
    {
        string[] REG_KEY =
        {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall",
            
        };
        
        public InstallsApp()
        {

        }

        // Миша, все хуйня !
        // Есби оно ввсе в попу 
        void FindInstalls(RegistryKey regKey, string[] keys, List<AppInf> installed)
        {
            
            foreach (string key in keys)
            {
                using (RegistryKey rk = regKey.OpenSubKey(key))
                {
                    if (rk == null)
                    {
                        continue;
                    }
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        //if (Regex.IsMatch(skName, @"{[\w\W]+?-[\w\W]+?-[\w\W]+?-[\w\W]+?-[\w\W]+?}"))
                        //    continue;
                        string data_install_path_ = "";
                        string data_install_name_ = "";
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            try
                            {
                                data_install_path_ = Convert.ToString(sk.GetValue("InstallLocation"));
                                data_install_name_ = Convert.ToString(sk.GetValue("DisplayName"));
                                if (data_install_path_ == string.Empty || data_install_path_ == "")
                                    continue;
                                if (data_install_name_ == string.Empty || data_install_name_ == "")
                                    continue;
                                AppInf appInf = new AppInf()
                                {
                                    Name = data_install_name_,
                                    InstallPath = data_install_path_.Replace("\"" , ""),
                                    RegistryKey = sk.ToString(),
                                };
                                installed.Add(appInf);
                            }
                            catch (Exception ex)
                            {
                                f_ErrorLog(ex.Message);
                            }
                        }
                    }
                }
            }   
        }
        public List<AppInf> GetInstallsApp()
        {
            List<AppInf> installs = new List<AppInf>();
            FindInstalls(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64), REG_KEY, installs);
            FindInstalls(RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64), REG_KEY, installs);
            //installs = installs.Where(s => !string.IsNullOrWhiteSpace(s.Name)).Distinct().ToList();
            //installs.Sort();
            return installs;
        }
         


    }
}
