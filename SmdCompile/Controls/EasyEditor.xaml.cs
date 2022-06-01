using SmdCompileLib.Model;
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
using UI.SyntaxBox;

namespace SmdCompile.Controls
{
    /// <summary>
    /// Логика взаимодействия для EasyEditor.xaml
    /// </summary>
    public partial class EasyEditor : UserControl
    {

        public Action<System.Windows.Input.Key> BindKeyDown;
        SyntaxJson syntaxJson = new SyntaxJson();

        public EasyEditor()
        {
            InitializeComponent();
            OpenConfig();
            this.Loaded += (o, e) =>
            {
                OpenConfig();
            };
            TextEditor.KeyDown += (o, e) =>
            {
                if(BindKeyDown != null)
                    BindKeyDown(e.Key);
                
            };
        }
        public string Text
        {
            get
            {
                return TextEditor.Text;
            }
            set
            {
                TextEditor.Text = value;
            }
        }

        private void OpenConfig()
        {
            Syntax_Config.Clear();
            syntaxJson.Load();
            syntaxJson.EventOpen += (b) =>
            {
                if (b)
                {
                    if (syntaxJson.syntax == null)
                        return;
                    foreach (var item in syntaxJson.syntax)
                    {
                        try
                        {
                            if (!item.Value.IsRegex)
                            {
                                KeywordRule syntax_Config = new KeywordRule()
                                {
                                    Keywords = item.Value.Keywords,
                                    Op = DriverOperationType.GetType(item.Value.DriverOperation),
                                    Foreground = item.Value.Foreground.ToBrush(),
                                    Background = item.Value.Background.ToBrush(),

                                };

                                this.AddSyntax(syntax_Config);
                            }
                            else
                            {
                                RegexRule regexRule = new RegexRule
                                {
                                    Foreground = item.Value.Foreground.ToBrush(),
                                    Background = item.Value.Background.ToBrush(),
                                    Op = DriverOperationType.GetType(item.Value.DriverOperation),
                                    Pattern = item.Value.Keywords,

                                };
                                Syntax_Config.Add(regexRule);
                            }

                        }
                        catch (Exception)
                        { }

                    }
                    TextEditor.SetValue(SyntaxBox.EnabledProperty, true);
                }
                else
                {
                    TextEditor.SetValue(SyntaxBox.EnabledProperty, false);
                }
            };



        }
        public void AddSyntax(ISyntaxRule syntaxRule)
        {
            Syntax_Config.Add(syntaxRule);
        }
    }
}
