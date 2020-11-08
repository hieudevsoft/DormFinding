using Facebook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
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
using System.Windows.Shapes;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
   
    public partial class MainControl : Window
    {
        private Uri uriPhoto;
        private BitmapImage imageAvatar;
        private FacebookClient _Fbc;
        private string id { get; set; }
        public MainControl(FacebookClient fbC)
        {
            InitializeComponent();
            this._Fbc = fbC;
            try
            {
                dynamic me = fbC.Get("Me");
                MessageBox.Show("Đăng nhập Facebook thành công");
                uriPhoto = new Uri("https://graph.facebook.com/" + me.id.ToString() + "/picture/");
                imageAvatar = new BitmapImage(uriPhoto);
            }
            catch(Exception e)
            {

            }
        }
        public MainControl()
        {
            InitializeComponent();
        }
        private string getLogoutUri()
        {
            var _logoutUri = _Fbc.GetLogoutUrl(new { access_token = _Fbc.AccessToken, next = "https://www.facebook.com/connect" });
            return _logoutUri.ToString();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    wbLogout.Visibility = Visibility.Visible;
        //    Debug.Print(getLogoutUri());
        //    wbLogout.Navigate(new Uri(getLogoutUri(),UriKind.Absolute));
        //    MainWindow lg = new MainWindow();
        //    lg.Show();
        //}
    }
}
