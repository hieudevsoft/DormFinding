using DormFinding.Models;
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
        private List<Dorm> listDorm = new List<Dorm>();
        private List<Dorm> listDormVerti = new List<Dorm>();
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

            listDormVerti = Mydatabase.getAllListDorm();
            listViewVerti.ItemsSource = listDormVerti;
            
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
