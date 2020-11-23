using DormFinding.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for MyDorm.xaml
    /// </summary>
    public partial class MyDorm : UserControl
    {
        private List<BookDorm> list;
        private User owner;
        public MyDorm(User user)
        {
            InitializeComponent();
            owner = user;
            initState();
        }

        private void initState()
        {
            list = Mydatabase.getAllWattingBookDorm(owner.Email);
            if (list.Count != 0)
            {
                notifyMyDorm.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                notifyMyDorm.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnNotify_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(list.Count.ToString());
        }
    }
}
