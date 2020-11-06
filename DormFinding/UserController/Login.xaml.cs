using DormFinding.Utils;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnCreateAccount_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCreateAccount.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void btnCreateAccount_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCreateAccount.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tbForgetPass_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbForgetPass.Foreground = new SolidColorBrush(Colors.Gray);
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
    }
}
