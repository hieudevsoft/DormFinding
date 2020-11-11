using Facebook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        private DispatcherTimer dispatcherTimer;
       
        public SignUp()
        {
            InitializeComponent();
            
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnMinimizedWindow_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btnLoginR_MouseMove(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoginR_MouseLeave(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush(Colors.Blue);
        }
        private void btnSignUp_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSignUp.Foreground = new SolidColorBrush(Colors.White);
            btnSignUp.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnSignUp_MouseMove(object sender, MouseEventArgs e)
        {
            btnSignUp.Foreground = new SolidColorBrush(Colors.Black);
            btnSignUp.Background = new SolidColorBrush(Colors.White);
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            icLoading.Visibility = Visibility.Visible;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TimerOnTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 2);
            dispatcherTimer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            icLoading.Visibility = Visibility.Collapsed;
        }

        private void btnLoginR_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
