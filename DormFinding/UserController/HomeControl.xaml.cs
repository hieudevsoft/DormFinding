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
        private User user;
        public HomeControl(User user)
        {
            InitializeComponent();
            this.user = user;
            setUpListViewHori();
            setUpListViewVerti();
            TransitioningContentSlide.OnApplyTemplate();
        }

        private void setUpListViewHori()
        {
            listDorm = Mydatabase.getAllListDorm();
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
            layoutMainDorm.Children.Add(new ShowDorm(dorm,user));
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

        private void listViewHori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dorm dorm = listViewHori.SelectedItem as Dorm;
            layoutMainDorm.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            layoutMainDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutMainDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutMainDorm.Width = 1120;
            layoutMainDorm.Height = 690;
            layoutMainDorm.Children.Add(new ShowDorm(dorm,user));
        }
    }
}
