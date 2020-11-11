namespace DormFinding
{
    using DormFinding.Models;
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            User user = Mydatabase.CheckAccountAreadyInApp();
            if (user != null)
            {
                MainControl m = new MainControl(user);
                m.Show();
                Window.GetWindow(this).Hide();
            }
            else
            {

            }
        }
    }
}