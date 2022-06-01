using SmdCompileLib.Model;

namespace SmdCompileLib.Steam
{
    public class SteamAccount
    {
        public string STEAM_Registry = @"HKEY_CURRENT_USER\Software\Valve\Steam";
        public SteamAccount()
        {

        }
        public override string ToString()
        {
            
            return $"Name:{LastGameNameUsed}\nSteamExe:\"{SteamExe}\"\nSteamPath:\"{SteamPath}\"";
        }
        public string LastGameNameUsed
        {
            get
            {
                return Reg.GetValue(STEAM_Registry, "LastGameNameUsed");
            }
        }

        public string SteamExe
        {
            get
            {
             

                return Reg.GetValue(STEAM_Registry, "SteamExe");
            }
        }
        public string SteamPath
        {
            get
            {
               

                return Reg.GetValue(STEAM_Registry, "SteamPath");
            }
        }
    }
}
