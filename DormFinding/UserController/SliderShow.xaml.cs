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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for SliderShow.xaml
    /// </summary>
    public partial class SliderShow : UserControl
    {
        private int index = 1;
        public SliderShow()
        {
            InitializeComponent();
            SetHover(btnNextSLiderShow);
            SetHover(btnPrevSLiderShow);
        }
        private void SetHover(Button button)
        {
            button.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                SetAnimationForButtonMove(button);

            };
            button.MouseLeave += delegate (object sender, MouseEventArgs e)
            {
                SetAnimationForButtonLeave(button);

            };
        }



        private void SetAnimationForButtonMove(Button bt)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0.5;
            animation.Duration = TimeSpan.FromSeconds(0.2);
            bt.BeginAnimation(OpacityProperty, animation);
        }

        private void SetAnimationForButtonLeave(Button bt)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.5;
            animation.To = 1;
            animation.Duration = TimeSpan.FromSeconds(0.2);
            bt.BeginAnimation(OpacityProperty, animation);
        }

        private void SetAnimationForImage(int from, int to)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.EasingFunction = new QuarticEase();
            borderImageSlider.BeginAnimation(WidthProperty, animation);
        }




        private void btnNextSLiderShow_Click(object sender, RoutedEventArgs e)
        {
            if (index == 4) index = 1; else index++;
            imageSlider.ImageSource = new BitmapImage(new Uri($"../../images/dorm_slide_{index}.jpg", UriKind.RelativeOrAbsolute));
            SetAnimationForImage(500, 1100);
        }

        private void btnPrevSLiderShow_Click(object sender, RoutedEventArgs e)
        {
            if (index == 1) index = 4;
            else index--;
            imageSlider.ImageSource = new BitmapImage(new Uri($"../../images/dorm_slide_{index}.jpg", UriKind.RelativeOrAbsolute));
            SetAnimationForImage(1700, 1100);
        }
    }
}
