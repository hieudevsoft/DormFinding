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
    /// Interaction logic for HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl
    {
        List<Dorm> listDorm = new List<Dorm>();

        public HomeControl()
        {
            InitializeComponent();
            setUpListViewHori();
            setUpListViewVerti();
            TransitioningContentSlide.OnApplyTemplate();
        }

        private void setUpListViewHori()
        {
            List<Dorm> listDorm = new List<Dorm>();
            Dorm dorm = new Dorm();
            dorm.Owner = "Hieu's House";
            dorm.Address = "Kim Giang Town, Ha Noi";
            dorm.Price = 120;
            dorm.Quality = 3;
            dorm.Image = new BitmapImage(new Uri("../../images/dorm_slide_2.jpg", UriKind.RelativeOrAbsolute));
            listDorm.Add(dorm);
            Dorm dorm1 = new Dorm();
            dorm1.Owner = "Hiep's House";
            dorm1.Address = "Tan Trieu Town, Ha Noi";
            dorm1.Price = 25;
            dorm1.Quality = 1;
            dorm1.Image = new BitmapImage(new Uri("../../images/dorm_slide_1.jpg", UriKind.RelativeOrAbsolute));
            listDorm.Add(dorm1);
            Dorm dorm2 = new Dorm();
            dorm2.Owner = "Truong's House";
            dorm2.Address = "CHien Thang Town, Ha Noi";
            dorm2.Price = 100;
            dorm2.Quality = 3;
            dorm2.Image = new BitmapImage(new Uri("../../images/dorm_slide_3.jpg", UriKind.RelativeOrAbsolute));
            listDorm.Add(dorm2);
            listViewHori.ItemsSource = listDorm;

        }
        private void setUpListViewVerti()
        {
          
            Dorm dorm = new Dorm();
            dorm.Owner = "Hieu's House";
            dorm.Address = "Kim Giang Town, Ha Noi";
            dorm.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.";
            dorm.Price = 120;
            dorm.Quality = 3;
            dorm.Sale = 40;
            dorm.Count = 10;
            dorm.CountLike = 20;
            dorm.IsWifi = Visibility.Collapsed;
            dorm.IsParking = Visibility.Collapsed;
            dorm.IsTelevision = Visibility.Collapsed;
            dorm.IsBathroom = Visibility.Visible;
            dorm.IsAirCondidition = Visibility.Collapsed;
            dorm.IsWaterHeater = Visibility.Visible;
            dorm.Image = new BitmapImage(new Uri("../../images/dorm_slide_2.jpg", UriKind.RelativeOrAbsolute));
            listDorm.Add(dorm);
            Dorm dorm1 = new Dorm();
            dorm1.Owner = "Hiep's House";
            dorm1.Address = "Tan Trieu Town, Ha Noi";
            dorm1.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.";
            dorm1.Price = 25;
            dorm1.Sale = 40;
            dorm1.Quality = 1;
            dorm1.Count = 10;
            dorm1.CountLike = 20;
            dorm1.IsWifi = Visibility.Collapsed;
            dorm1.IsParking = Visibility.Collapsed;
            dorm1.IsTelevision = Visibility.Collapsed;
            dorm1.IsBathroom = Visibility.Visible;
            dorm1.IsAirCondidition = Visibility.Collapsed;
            dorm1.IsWaterHeater = Visibility.Visible;
            dorm1.Image = new BitmapImage(new Uri("../../images/dorm_slide_1.jpg", UriKind.RelativeOrAbsolute));
            listDorm.Add(dorm1);
            Dorm dorm2 = new Dorm();
            dorm2.Owner = "Truong's House";
            dorm2.Address = "Chien Thang Town, Ha Noi";
            dorm2.Price = 100;
            dorm2.Sale = 10;
            dorm2.Quality = 3;
            dorm2.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.This is Test";
            dorm2.Count = 10;
            dorm2.CountLike = 20;
            dorm2.IsWifi = Visibility.Collapsed;
            dorm2.IsParking = Visibility.Collapsed;
            dorm2.IsTelevision = Visibility.Collapsed;
            dorm2.IsBathroom = Visibility.Visible;
            dorm2.IsAirCondidition = Visibility.Collapsed;
            dorm2.IsWaterHeater = Visibility.Visible;
            dorm2.Image = new BitmapImage(new Uri("../../images/dorm_slide_3.jpg", UriKind.RelativeOrAbsolute));
            listDorm.Add(dorm2);
            listDorm.Add(dorm);
            listViewVerti.ItemsSource = listDorm;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewVerti.ItemsSource);
            view.Filter = DormFilter;

        }

        private void listViewVerti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dorm dorm = listViewVerti.SelectedItem as Dorm;

            layoutMainDorm.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            layoutMainDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutMainDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutMainDorm.Width = 1120;
            layoutMainDorm.Height = 690;
            layoutMainDorm.Children.Add(new ShowDorm(dorm));
        }

       private bool DormFilter(Object item)
        {
            if (String.IsNullOrEmpty(searchQuery.Text)) return true;
            else return ((item as Dorm).Owner.IndexOf(searchQuery.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void searchQuery_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listViewVerti.ItemsSource).Refresh();
        }
    }
}
