using DormFinding.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        MySqlConnection mySqlConnection;
        const string connectDatabase = "SERVER=localhost;DATABASE=quanlydangnhap;UID=root;PASSWORD=;";
        public Login()
        {
            InitializeComponent();
            wbBrowser.Navigate(new Uri("https://www.facebook.com/oauth/authorize?client_id=1677950655708399&redirect_uri=https://www.facebook.com/connect/login_success.html&type=user_agent&display=popup", UriKind.Absolute));

        }
        private void btnCreateAccount_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCreateAccount.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void btnCreateAccount_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCreateAccount.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tbForgetPass_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbForgetPass.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbForgetPass_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbForgetPass.Foreground = new SolidColorBrush(Colors.DodgerBlue);
        }

        private void btnLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            btnLogin.Foreground = new SolidColorBrush(Colors.White);
            btnLogin.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnLogin_MouseMove(object sender, MouseEventArgs e)
        {
            btnLogin.Foreground = new SolidColorBrush(Colors.Black);
            btnLogin.Background = new SolidColorBrush(Colors.White);
        }

        private void btnMinimizedWindow_Click(object sender, RoutedEventArgs e)
        {
           Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
           System.Windows.Application.Current.Shutdown();
       }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
       {
            try
            {
               mySqlConnection = new MySqlConnection(connectDatabase);
                mySqlConnection.Open();
                if(mySqlConnection.State == ConnectionState.Open)
               {
                    MessageBox.Show("Connected");
                } else MessageBox.Show("Disconnected");
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
           }
           
            
        }

        private void btnFaceBook_Click(object sender, RoutedEventArgs e)
        {
            wbBrowser.Visibility = Visibility.Visible;
        }
        private void wbBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString().StartsWith("https://www.facebook.com/connect/login_success.html"))
            {
                MessageBox.Show(e.Uri.Fragment);
            }
        }

    }
}
