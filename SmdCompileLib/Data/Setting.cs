using Newtonsoft.Json;
using System;
using System.IO;

namespace SmdCompileLib.Data
{


    [Serializable]
    public class SettingWindow
    {
        public bool BlurWindow
        {
            get; set;
        } = false;

    }

    public class StudioMDLArgs
    {
        public string args
        {
            get; set;
        } = "-nop4 -verbose";

    }

    [Serializable]
    public class Setting
    {
        public string PathGame
        {
            get; set;
        } = "";
        public string Pathstudiomdl
        {
            get; set;
        } = "";
        public string NameGame
        {
            get; set;
        } = "";
        public string IdGame
        {
            get; set;
        } = "";
        public SettingWindow settingWindow
        {
            get; set;
        } = new SettingWindow();

        public StudioMDLArgs studioMDLArgs
        {
            get; set;
        } = new StudioMDLArgs();

    }
    public class JsonSetting
    {

        public string PathFileSettingJson = "Data/setting.json";
        public Action<string> Error;
        public Action<string> Message;
        public JsonSetting()
        {

        }
        public void Load()
        {

            try
            {
                if (File.Exists(PathFileSettingJson))
                {
                    string read_file_ = File.ReadAllText(PathFileSettingJson);
                    Setting obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Setting>(read_file_);
                    EveMessage($"DeserializeObject");
                    if (obj != null)
                    {
                        GLOBAL.setting = obj;
                        return;
                    }
                    EveMessage($"NULL");
                }
                else
                {
                    // Кря!
                    Save();
                    // Я уточка Кря Кря!
                }



            }
            catch (Exception e)
            {
                EveError(e.Message);

            }
            EveMessage($"Load");
        }
        public void EveError(string message)
        {
            if(Error != null)
                this.Error(message);
        }

        public void EveMessage(string message)
        {
            if (Message != null)
                this.Message(message);
        }
        public void Save()
        {
            try
            {
                string json_obj_ = JsonConvert.SerializeObject(GLOBAL.setting , Formatting.Indented);

                EveMessage($"SerializeObject");

                DirectoryInfo dir_ = new FileInfo(PathFileSettingJson).Directory;
                if (!dir_.Exists)
                {
                    Directory.CreateDirectory(dir_.FullName);

                    EveMessage($"CreateDirectory: {dir_.FullName}");
                }
                File.WriteAllText(PathFileSettingJson, json_obj_);

                EveMessage($"WriteAllText: {PathFileSettingJson}");
            }
            catch (Exception e)
            {

                EveError(e.Message);
            }
            EveMessage($"Save");
        }
    }
}
