using SmdCompileLib.Data;
using SmdCompileLib.Model;
using SmdCompileLib.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmdCompile.Page
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : UserControl 
    {
        public Action<string> UpdateSetting;
        FileFInder filefInder = new FileFInder();
        FileFInder filefInder_studiomdl = new FileFInder();
        public Setting()
        {
            InitializeComponent();
            path_TextBox.KeyDown += Path_TextBox_KeyDown;
            blured_chbox.Changed += blured_chbox_Changed;
            button_openfolderdialog.PreviewMouseLeftButtonDown += Button_openfolderdialog_PreviewMouseLeftButtonDown;
            button_getinstallapplication.PreviewMouseLeftButtonDown += Button_getinstallapplication_PreviewMouseLeftButtonDown;
            install_app.EventMouseDown += EventMouseDown_path;
            this.Loaded += Setting_Loaded;

        }

        private void Setting_Loaded(object sender, RoutedEventArgs e)
        {
            SetPathGame(GLOBAL.setting.PathGame);

            blured_chbox.IsChecked = GLOBAL.setting.settingWindow.BlurWindow;
        }

        private void EventMouseDown_path(string path)
        {
   
            SetPathGame(path);
        }
        private void Button_getinstallapplication_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (install_app.Visibility)
            {
                case Visibility.Visible:
                    install_app.Visibility = Visibility.Hidden;
                    break;
                case Visibility.Hidden:
                    install_app.Visibility = Visibility.Visible;
                    break;
                case Visibility.Collapsed:
                    break;
                default:
                    break;
            }
        }

        private void Button_openfolderdialog_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fd = new System.Windows.Forms.FolderBrowserDialog();
            if(fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               

                SetPathGame(fd.SelectedPath);
                Console.WriteLine(GLOBAL.setting.PathGame);
            }
            f_UpdateSetting("openfiledialog");
        }

        public void f_UpdateSetting() => f_UpdateSetting("");
        public void f_UpdateSetting( string msg)
        {
            if (UpdateSetting != null)
                UpdateSetting(msg);
        }
        private void blured_chbox_Changed(bool b)
        {
            GLOBAL.setting.settingWindow.BlurWindow = b;
            f_UpdateSetting("BlurWindow");
        }
        private void Path_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            SetPathGame((sender as TextBox).Text);
        }
        void SetPathGame(string path)
        {
            filefInder.LocalPath  = path;
            filefInder.RegexPattern = "steam_appid.txt";
            filefInder.Find();
             

            if (filefInder.IsExists)
            {
                GLOBAL.setting.PathGame = path_TextBox.Text = path;

                label_steam_appid.IsChecked = true;

                filefInder_studiomdl.LocalPath = filefInder.LocalPath;
                filefInder_studiomdl.RegexPattern = "studiomdl.exe";
                filefInder_studiomdl.Find();

                if (filefInder_studiomdl.IsExists)
                {
                    label_studiomdl.IsChecked = true;
                    GLOBAL.setting.Pathstudiomdl = filefInder_studiomdl.Result;

                }
                else
                {
                    label_studiomdl.IsChecked = false;
                    GLOBAL.setting.Pathstudiomdl = string.Empty;
                }

            }
            else
            {
                GLOBAL.setting.PathGame = path_TextBox.Text = string.Empty;
                GLOBAL.setting.Pathstudiomdl = string.Empty;
                label_studiomdl.IsChecked = label_steam_appid.IsChecked = false;  
                
            }
            f_UpdateSetting("PathGame");

        }
    }
}
