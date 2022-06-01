using SmdCompileLib.Steam;
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

namespace SmdCompile.Controls
{
    /// <summary>
    /// Логика взаимодействия для SteamUser.xaml
    /// </summary>
    public partial class SteamUser : UserControl
    {
        SteamAccount steamAccount = new SteamAccount();
        public SteamUser()
        {
            InitializeComponent();
            this.Loaded += (o, e) =>
            {
                UpdateUserName();
            };
        }
        public void UpdateUserName()
        {
            UserName = steamAccount.LastGameNameUsed;
        }
        public string UserName
        {
            get
            {
                return LabelUserName.Content as string;
            }
            set
            {
                LabelUserName.Content = value;
            }
        }
    }
}
