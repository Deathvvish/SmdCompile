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

namespace FluentUI.Controls
{
    /// <summary>
    /// Логика взаимодействия для CheckBox.xaml
    /// </summary>
    public partial class CheckBox : UserControl
    {

        public Action<bool> Changed;

        bool _IsChecked = false;
        public object Text
        {
            get
            {
                return label.Content;
            }
            set
            {
                label.Content = value;
                
            }
        }
        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                _IsChecked = value;
                CheckedChanged();
            }
        }
        public CheckBox()
        {
            InitializeComponent();

            this.Loaded += (o, e) =>
            {
                CheckedChanged();
            };
           
            this.MouseDown += (o, e) =>
            {
                IsChecked = !IsChecked;
            };
        }
        public virtual void CheckedChanged()
        {
            if (IsChecked)
            {
                hi_f.Visibility = Visibility.Collapsed;
                ch_t.Visibility = Visibility.Visible;
            }
            else
            {
                ch_t.Visibility = Visibility.Collapsed;
                hi_f.Visibility = Visibility.Visible;
            }
            if (Changed != null)
                Changed(IsChecked);
        }
    }
}
