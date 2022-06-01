using SmdCompile.Controls;
using System;
using System.Collections.Generic;
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

namespace SmdCompile.Page
{
    /// <summary>
    /// Логика взаимодействия для QCEditor.xaml
    /// </summary>
    public partial class QCEditor : UserControl
    {
        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher()
        {
            Path = "Syntax",
            EnableRaisingEvents = true,
        };
        private string _DATASTRING_ = "";
        private EasyEditor easyEditor;

        public QCEditor()
        {
            InitializeComponent();
            easyEditor = new EasyEditor();
            Compile_Editors.Children.Clear();
            Compile_Editors.Children.Add(easyEditor);

            fileSystemWatcher.Changed += (od, ed) =>
            {
                Thread.Sleep(100);
                this.Dispatcher.BeginInvoke((ThreadStart)delegate ()
                {
                    if (ed.Name == "qc_.json")
                    {
                        if (Compile_Editors.Children.Count > 0)
                        {
                            _DATASTRING_ = easyEditor.Text;

                            Compile_Editors.Children.Clear();
                            easyEditor = new EasyEditor();
                            easyEditor.Loaded += (dod, dd) =>
                            {
                                easyEditor.Text = _DATASTRING_;
                            };



                            Compile_Editors.Children.Add(easyEditor);

                        }

                    }
                }, new object[] { });

            };
        }
    }
}
