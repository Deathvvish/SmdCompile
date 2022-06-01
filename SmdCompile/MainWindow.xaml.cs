using SmdCompile.Controls;
using SmdCompileLib.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SmdCompile
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JsonSetting jsonSetting = new JsonSetting();
       

        public void SetMargin(int m)
        {
            mian_border_.Margin = new Thickness(m);
        }
        public MainWindow()
        {
            jsonSetting.Load();

            InitializeComponent();


            

            this.Loaded += (o, e) =>
            {
                resizewindow.window = winbuttons.window = this;
                new WinDragMove(this, grid_top_move);

                
                
            };
            button_user_profile.MouseDown += (o, e) =>
            {
                SteamUser_.VisibInv();
            };
            setting_.UpdateSetting += (msg) =>
            {
                switch (msg)
                {
                    case "BlurWindow":
                        switch (GLOBAL.setting.settingWindow.BlurWindow)
                        {
                            case true:
                                new WindowBlureffect(this, WindowBlureffect.AccentState.ACCENT_ENABLE_BLURBEHIND);
                                break;
                            case false:
                                new WindowBlureffect(this, WindowBlureffect.AccentState.ACCENT_DISABLED);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                jsonSetting.Save();
                 
            };
        }

        private void Label_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://steamcommunity.com/id/UnderKo/");
        }

        private void Label_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText("UnderKo#2559");
        }
    }
}
