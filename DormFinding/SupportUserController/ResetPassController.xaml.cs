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

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for ResetPassController.xaml
    /// </summary>
    public partial class ResetPassController : UserControl
    {
        public ResetPassController()
        {
            InitializeComponent();
        }

        private void btnLoginR_MouseMove(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE46B"));

        }

        private void btnLoginR_MouseLeave(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4F8F7"));
        }
        private void btnMinimizedWindow_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
