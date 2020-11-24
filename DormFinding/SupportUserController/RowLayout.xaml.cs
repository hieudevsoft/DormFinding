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
    /// Interaction logic for RowLayout.xaml
    /// </summary>
    public partial class RowLayout : UserControl
    {
        public RowLayout()
        {
            InitializeComponent();
            TransitioningContentSlide.OnApplyTemplate();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Dorm dorm = button.DataContext as Dorm;
            if (Mydatabase.deleteDorm(dorm.Id))
            {
                Mydatabase.deleteDormBookDorm(dorm.Id);
                Mydatabase.deleteDormOwnerDorm(dorm.Id);
                Mydatabase.deleteOwnerLikeDorm(dorm.Id);
                MainControl mainControl = (MainControl)Window.GetWindow(this);
                mainControl.MainHomeLayout.Children.Clear();
                mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                mainControl.MainHomeLayout.Width = 1150;
                mainControl.MainHomeLayout.Height = 690;
                mainControl.MainHomeLayout.Children.Add(new MyDorm(mainControl.user));
            }
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Dorm dorm = button.DataContext as Dorm;
            MainControl mainControl = (MainControl)Window.GetWindow(this);
            mainControl.MainHomeLayout.Children.Clear();
            mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
            mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
            mainControl.MainHomeLayout.Width = 1150;
            mainControl.MainHomeLayout.Height = 690;
            mainControl.MainHomeLayout.Children.Add(new PostDorm(mainControl.user, dorm));
        }
    }
}
