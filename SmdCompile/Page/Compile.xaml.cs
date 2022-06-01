using SmdCompile.Controls;
using SmdCompileLib.Data;
using SmdCompileLib.Model;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmdCompile.Page
{
    /// <summary>
    /// Логика взаимодействия для Compile.xaml
    /// </summary>
    public partial class Compile : UserControl
    {

        FileSystemWatcher fileSystemWatcher_Syntax;
        FileSystemWatcher fileSystemWatcher_Models;
        private string _DATASTRING_ = "";
        private EasyEditor easyEditor;
        private SmdCompileLib.Model.Process process_p;
        string[] DIRS =
        {
            "Syntax",
            "Models"
        };
        private string Location = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private string DATA_FULLPATH_QC = "";


        public Compile()
        {
            InitializeComponent();

            {
                if (!Directory.Exists(DIRS[0]))
                    Directory.CreateDirectory(DIRS[0]);
                fileSystemWatcher_Syntax = new FileSystemWatcher()
                {
                    Path = DIRS[0],
                    EnableRaisingEvents = true,
                };
                if (!Directory.Exists(DIRS[1]))
                    Directory.CreateDirectory(DIRS[1]);
                fileSystemWatcher_Models = new FileSystemWatcher()
                {
                    Path = DIRS[1],
                    EnableRaisingEvents = true,
                };
                CreateNewEditor();
            }
            conv_o.MouseLeftButtonDown += (o, e) =>
            {
                compile_(DATA_FULLPATH_QC);
            };
            conv_a.MouseLeftButtonDown += (o, e) =>
            {
                foreach (Controls.ProgItems item in list_projects.Items)
                {
                    string name_qc = item.PathQCFile;
                    DATA_FULLPATH_QC = Path.Combine(Location, name_qc);
                    if (File.Exists(DATA_FULLPATH_QC))
                    {
                        
                        compile_(DATA_FULLPATH_QC);
                    }
                    else
                    {
                        DATA_FULLPATH_QC = string.Empty;
                    }
                }
                
            };



            fileSystemWatcher_Syntax.Changed += (od, ed) =>
            {
                Thread.Sleep(100);
                this.Dispatcher.BeginInvoke((ThreadStart)delegate ()
                {
                    if (ed.Name == "qc_.json")
                    {
                        if (Compile_Editors.Children.Count > 0)
                        {
                            if(easyEditor != null)
                                _DATASTRING_ = easyEditor.Text;
                            CreateNewEditor();
                        }
                    }
                }, new object[] { });

            };

            fileSystemWatcher_Models.Changed += FileSystemWatcher_Models_Changed;
            fileSystemWatcher_Models.Created += FileSystemWatcher_Models_Changed;
            fileSystemWatcher_Models.Deleted += FileSystemWatcher_Models_Changed;

            UpdateFiles();


            list_projects.SelectionChanged += (o, e) =>
            {
                if (list_projects.Items.Count == 0)
                    return;
                string name_qc = (list_projects.Items[list_projects.SelectedIndex] as Controls.ProgItems).PathQCFile;

                DATA_FULLPATH_QC = Path.Combine(Location, name_qc);
                if (!File.Exists(DATA_FULLPATH_QC))
                {
                    DATA_FULLPATH_QC = string.Empty;
                }
               
                    
            };

        }
        void compile_( string path_qc)
        {
            bool b = !File.Exists(GLOBAL.setting.Pathstudiomdl) || !File.Exists(path_qc);
            if (b)
                return;

            process_p = new Process()
            {
                FileName = GLOBAL.setting.Pathstudiomdl,
                
            };
            string[] path_ =
            {
                
                Path.Combine(GLOBAL.setting.PathGame, "garrysmod"),
                Path.Combine(GLOBAL.setting.PathGame, "csgo"),

            };
            foreach (var item in path_)
            {
                if (Directory.Exists(item))
                {
                    process_p.Args = $"-game \"{item}\" {GLOBAL.setting.studioMDLArgs.args} \"{path_qc}\"";
                    break;
                }

            }


            process_p.EventDataReceivedHandler += (o, e) =>
            {
                this.Dispatcher.BeginInvoke(new Action(() => 
                {
                    TextBox_Log.Text += e.Data + "\n";


                }));
                
            };
            process_p.Start();



        }
        void CreateNewEditor()
        {
            Compile_Editors.Children.Clear();
            easyEditor = new EasyEditor();
            easyEditor.BindKeyDown += (key) =>
            {
                Console.WriteLine($"{key} {key == Key.LeftCtrl && Keyboard.IsKeyDown(Key.V)}");
            };
            easyEditor.Loaded += (dod, dd) =>
            {
                easyEditor.Text = _DATASTRING_;
            };
            Compile_Editors.Children.Add(easyEditor);
        }
        private void FileSystemWatcher_Models_Changed(object sender, FileSystemEventArgs e)
        {
            this.Dispatcher.BeginInvoke((ThreadStart)delegate ()
            {
                UpdateFiles();
            }, new object[] { });
        }

        void UpdateFiles()
        {
            
            list_projects.Items.Clear();
            if (Directory.Exists(DIRS[1]))
                foreach (var item in Directory.GetDirectories(DIRS[1]))
                {
                    Controls.ProgItems progItems = new ProgItems()
                    {
                        NameProj = new FileInfo(item).Name,
                        Path = item,
                    };
                    progItems.MouseDown_path += (str , qc) => {

                        if(easyEditor != null && File.Exists(qc))
                        {

                            easyEditor.Text = File.ReadAllText(qc);
                        }

                         
                    };
                    list_projects.Items.Add(progItems);

                }
        }
        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            string DATA_NAME = "";
            string DATA_PATH = "";
            string DATA_FULLPATH = "";
            string DATA_FULLPATH_QC_file = "";
            FileInfo fileInfo;
            MReplace mReplace = new MReplace();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var item in files)
                {
                    if (!File.Exists(item))
                        continue;

                    fileInfo = new FileInfo(item);
                    if(!Regex.IsMatch(fileInfo.Extension.ToLower() , "(.smd)|(.dmx)"))
                    {


                        continue;
                    }

                    DATA_NAME = fileInfo.Name.Replace(fileInfo.Extension,"").GetString("[\\w]+");

                    DATA_PATH = Path.Combine(fileSystemWatcher_Models.Path, DATA_NAME);

                    if (!Directory.Exists(DATA_PATH))
                        Directory.CreateDirectory(DATA_PATH);

                    

                    DATA_FULLPATH = Path.Combine(DATA_PATH, DATA_NAME + fileInfo.Extension);
                    if (File.Exists(DATA_FULLPATH))
                        File.Delete(DATA_FULLPATH);
                    File.Copy(item, DATA_FULLPATH);


                    

                    DATA_FULLPATH_QC_file = Path.Combine(DATA_PATH, "qc_file.qc");

                    mReplace.DATA = System.Text.Encoding.Default.GetString(Properties.Resources.init);

                    mReplace.Replace("_material_", "models/texture_my_test/");
                    mReplace.Replace("_model_", $"{Path.Combine(DATA_NAME, DATA_NAME)}");
                    mReplace.Replace("_mass_object_", 25);
                    mReplace.Replace("_VIIVIVI_", $"{DATA_NAME}.smd");
                    mReplace.Replace("_inertia_object_", 0);
                    mReplace.Replace("_scale_", 1);
                   

                    File.WriteAllText(DATA_FULLPATH_QC_file, mReplace.DATA);

                }


            }
        }

        /// <summary>
        /// save file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editor_save_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (File.Exists(DATA_FULLPATH_QC) && easyEditor != null)
                File.WriteAllText(DATA_FULLPATH_QC, easyEditor.Text);
        }
    }
}
