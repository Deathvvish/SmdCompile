using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmdCompile.Controls
{
    public class DListBox : ListBox
    {
        public DListBox()
        {
            this.Background = Brushes.Transparent;
            this.BorderThickness = new System.Windows.Thickness(0);
             
        }
    }
}
