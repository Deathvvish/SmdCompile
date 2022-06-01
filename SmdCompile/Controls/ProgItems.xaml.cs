using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace SmdCompile.Controls
{
    /// <summary>
    /// Логика взаимодействия для ProgItems.xaml
    /// </summary>
    public partial class ProgItems : UserControl
    {
        public Action<string,string> MouseDown_path;
        public string NameProj
        {
            get
            {
                return NameProj_.Content as string;
            }
            set
            {
                NameProj_.Content = value;
            }
        }
        public string Path
        {
            get
            {
                return Path_.Content as string;
            }
            set
            {
                Path_.Content = value;
            }
        }
        public ProgItems()
        {
            InitializeComponent();
            this.PreviewMouseRightButtonDown += (o, e) =>
            {
                if (Directory.Exists(Path))
                    Process.Start(Path);
            };
            this.PreviewMouseLeftButtonDown += (o, e) =>
            {
                if (MouseDown_path != null)
                    MouseDown_path(Path , PathQCFile);
            };
        }
        public string PathQCFile
        {
            get
            {
                return System.IO.Path.Combine(Path, "qc_file.qc");
            }
        }
    }
}
