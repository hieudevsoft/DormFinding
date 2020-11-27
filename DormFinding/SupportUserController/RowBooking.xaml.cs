using DormFinding.Models;
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
    /// Interaction logic for RowBooking.xaml
    /// </summary>
    public partial class RowBooking : UserControl
    {
        public RowBooking()
        {
            InitializeComponent();
        }

        private void btnConfirmBook_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            BookDorm dorm = button.DataContext as BookDorm;
            if (Mydatabase.updateDormWhenBook(dorm.EmailOwner, dorm.EmailUser, dorm.IdDorm))
            {
                if(Mydatabase.deleteDormWhenBook(dorm.EmailOwner, dorm.EmailUser, dorm.IdDorm))
                {
                    Helpers.MakeConfirmMessage(Window.GetWindow(this), $"The Dorm has been transferred to { dorm.EmailUser}", "Notify");
                    int count = Mydatabase.getCountDorm(dorm.IdDorm) + 1;
                    Mydatabase.updateCountDorm(dorm.IdDorm, count);
                    MainControl mainControl = (MainControl)Window.GetWindow(this);
                    mainControl.MainHomeLayout.Children.Clear();
                    mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    mainControl.MainHomeLayout.Width = 1150;
                    mainControl.MainHomeLayout.Height = 690;
                    mainControl.MainHomeLayout.Children.Add(new MyDorm(mainControl.user));
                }
                else
                {
                    Helpers.MakeErrorMessage(Window.GetWindow(this), $"Failed transferred to {dorm.EmailUser}", "Error");
                }
            }
        }
    }
}
