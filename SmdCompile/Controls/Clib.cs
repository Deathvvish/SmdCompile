using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmdCompile.Controls
{
    static class Clib
    {
        public static void VisibInv( this FrameworkElement frameworkElement)
        {
            switch (frameworkElement.Visibility)
            {
                case Visibility.Visible:
                    frameworkElement.Visibility = Visibility.Hidden;
                    break;
                case Visibility.Hidden:
                    frameworkElement.Visibility = Visibility.Visible;
                    break;
                case Visibility.Collapsed:
                    break;
                default:
                    break;
            }
        }
    }
}
