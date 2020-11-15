using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        
        public Profile()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Resources["colorBackGroundMode"] = new SolidColorBrush(Colors.White);
            TransitioningContentSlide1.OnApplyTemplate();
            TransitioningContentSlide2.OnApplyTemplate();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbDarkMode_Checked(object sender, RoutedEventArgs e)
        {
            openDarkMode();
            
        }

        private void tbDarkMode_Unchecked(object sender, RoutedEventArgs e)
        {
            closeDarkMode();
        }

        private void openDarkMode()
        {
            this.Resources["colorBackGroundMode"] = new SolidColorBrush(Color.FromRgb(49,49,49));
            this.Resources["colorLightMode"] = new SolidColorBrush(Colors.White);
            txtDarkMode.Text = "Dark Mode";
        }

        private void closeDarkMode()
        {
            this.Resources["colorBackGroundMode"] = new SolidColorBrush(Colors.White);
            this.Resources["colorLightMode"] = new SolidColorBrush(Color.FromRgb(49, 49, 49));
            txtDarkMode.Text = "Light Mode";
        }
    }
}
