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
    /// Логика взаимодействия для PageInstallApplication.xaml
    /// </summary>
    public partial class PageInstallApplication : UserControl
    {
        InstallsApp installsApp = new InstallsApp();
        public Action<string> EventMouseDown;
        public PageInstallApplication()
        {

            InitializeComponent();
            this.Loaded += (o, e) =>
            {
                foreach (var item in installsApp.GetInstallsApp())
                {
                    Label l = new Label()
                    {
                        Content = item.Name,
                        Foreground = Brushes.White,
                        FontSize = 19,
                        HorizontalAlignment = HorizontalAlignment.Left,
                    };
                    l.PreviewMouseLeftButtonDown += (od, ed) =>
                    {
                        if (EventMouseDown != null)
                            EventMouseDown(item.InstallPath);
                    };
                    listapp.Items.Add(l);
                }
                
            };
        }
    }
}
