using DormFinding.Models;
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
using System.Windows.Media.Animation;
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
        private User user;
        private string id { get; set; }
        public MainControl(FacebookClient fbC)
        {
            InitializeComponent();       
            try
            {
                this._Fbc = fbC;
                dynamic me = fbC.Get("Me");
                MessageBox.Show("Đăng nhập Facebook thành công");
                uriPhoto = new Uri("https://graph.facebook.com/" + me.id.ToString() + "/picture/");
                imageAvatar = new BitmapImage(uriPhoto);
            }
            catch(Exception e)
            {

            }
        }
        public MainControl(User user)
        {
            InitializeComponent();
            this.user = user;
            

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

        private void btnExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            DoubleAnimation doubleAnimation2 = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation2.From = 1;
            doubleAnimation2.To = 0;
            btnOpenMenu.BeginAnimation(OpacityProperty, doubleAnimation);
            btnCloseMenu.BeginAnimation(OpacityProperty, doubleAnimation2);
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;

        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            DoubleAnimation doubleAnimation2 = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation2.From = 1;
            doubleAnimation2.To = 0;
            btnOpenMenu.BeginAnimation(OpacityProperty, doubleAnimation2);
            btnCloseMenu.BeginAnimation(OpacityProperty, doubleAnimation);
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wbLogout.Visibility = Visibility.Visible;
            Debug.Print(getLogoutUri());
            wbLogout.Navigate(new Uri(getLogoutUri(),UriKind.Absolute));
            MainWindow lg = new MainWindow();
            lg.Show();
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                user.isRemember = 0;
                Mydatabase.Update(user, user.Email);
                MainWindow m = new MainWindow();
                m.Show();
                this.Hide();
            }
        }

        private void ListViewSideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewSideBar.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 0:
                    MainHomeLayout.Children.Clear();
                    MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    MainHomeLayout.Children.Add(new HomeControl());
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            SlideCursor.Margin = new Thickness(0, (14 + (index * 92)), 0, 0);
            SlideCursor.Visibility = Visibility.Visible;
            switch (index)
            {
                case 2: SlideCursor.Margin = new Thickness(0, (15 + (index * 95)), 0, 0);break;
                case 3 : SlideCursor.Margin = new Thickness(0, (10 + (index * 97)), 0, 0);break;
                default: SlideCursor.Margin = new Thickness(0, (14 + (index * 92)), 0, 0);break;
            }
                

        }
    }
}
