using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmdCompile.Controls
{
    public class lico : Label
    {
        public lico()
        {
            this.FontSize = 20;
            this.Background = Brushes.Transparent;
            this.Foreground = Brushes.White;
            
            this.Padding = this.Margin = new System.Windows.Thickness();
            this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            this.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
        }
        
    }
}
