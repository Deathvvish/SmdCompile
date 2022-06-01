using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmdCompileLib.stm
{
    public static class wins
    {
        public static void SetMargin(this FrameworkElement frameworkElement , int m)
        {
            frameworkElement.Margin = new Thickness(m);
        }
        public static void SetMargin(this Window frameworkElement, int m)
        {
            frameworkElement.Margin = new Thickness(m);
        }
    }
}
