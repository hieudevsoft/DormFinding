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
    /// Interaction logic for ShowDorm.xaml
    /// </summary>




    public partial class ShowDorm : UserControl
    {
        private Dorm dorm;

        private bool click = false;
        public BitmapImage ImageDorm
        {
            get { return (BitmapImage)GetValue(ImageDormProperty); }
            set { SetValue(ImageDormProperty, value); }
        }
        public static readonly DependencyProperty ImageDormProperty =
            DependencyProperty.Register("ImageDorm", typeof(BitmapImage), typeof(ShowDorm));
        public string OwnerDorm
        {
            get { return (string)GetValue(OwnerDormProperty); }
            set { SetValue(OwnerDormProperty, value); }
        }
        public static readonly DependencyProperty OwnerDormProperty =
            DependencyProperty.Register("OwnerDorm", typeof(string), typeof(ShowDorm));
        public string AddressDorm
        {
            get { return (string)GetValue(AddressDormProperty); }
            set { SetValue(AddressDormProperty, value); }
        }
        public static readonly DependencyProperty AddressDormProperty =
            DependencyProperty.Register("AddressDorm", typeof(string), typeof(ShowDorm));
        public string DesDorm
        {
            get { return (string)GetValue(DesDormProperty); }
            set { SetValue(DesDormProperty, value); }
        }
        public static readonly DependencyProperty DesDormProperty =
            DependencyProperty.Register("DesDorm", typeof(string), typeof(ShowDorm));
        public string PriceDorm
        {
            get { return (string)GetValue(PriceDormProperty); }
            set { SetValue(PriceDormProperty, value); }
        }
        public static readonly DependencyProperty PriceDormProperty =
            DependencyProperty.Register("PriceDorm", typeof(string), typeof(ShowDorm));
        public int QualityDorm
        {
            get { return (int)GetValue(QualityDormProperty); }
            set { SetValue(QualityDormProperty, value); }
        }
        public static readonly DependencyProperty QualityDormProperty =
            DependencyProperty.Register("QualityDorm", typeof(int), typeof(ShowDorm));
        public string CountDorm
        {
            get { return (string)GetValue(CountDormProperty); }
            set { SetValue(CountDormProperty, value); }
        }
        public static readonly DependencyProperty CountDormProperty =
            DependencyProperty.Register("CountDorm", typeof(string), typeof(ShowDorm), new PropertyMetadata("0"));
        public Visibility WifiDorm
        {
            get { return (Visibility)GetValue(WifiDormProperty); }
            set { SetValue(WifiDormProperty, value); }
        }
        public static readonly DependencyProperty WifiDormProperty =
            DependencyProperty.Register("WifiDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility ParkingDorm
        {
            get { return (Visibility)GetValue(ParkingDormProperty); }
            set { SetValue(ParkingDormProperty, value); }
        }
        public static readonly DependencyProperty ParkingDormProperty =
            DependencyProperty.Register("ParkingDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility TelevisionDorm
        {
            get { return (Visibility)GetValue(TelevisionDormProperty); }
            set { SetValue(TelevisionDormProperty, value); }
        }
        public static readonly DependencyProperty TelevisionDormProperty =
            DependencyProperty.Register("TelevisionDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility BathroomDorm
        {
            get { return (Visibility)GetValue(BathroomDormProperty); }
            set { SetValue(BathroomDormProperty, value); }
        }
        public static readonly DependencyProperty BathroomDormProperty =
            DependencyProperty.Register("BathroomDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility AirConditionerDorm
        {
            get { return (Visibility)GetValue(AirConditionerDormProperty); }
            set { SetValue(AirConditionerDormProperty, value); }
        }
        public static readonly DependencyProperty AirConditionerDormProperty =
            DependencyProperty.Register("AirConditionerDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility WaterHeaterDorm
        {
            get { return (Visibility)GetValue(WaterHeaterDormProperty); }
            set { SetValue(WaterHeaterDormProperty, value); }
        }
        public static readonly DependencyProperty WaterHeaterDormProperty =
            DependencyProperty.Register("WaterHeaterDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public int CountLikeDorm
        {
            get { return (int)GetValue(CountLikeDormProperty); }
            set { SetValue(CountLikeDormProperty, value); }
        }
        public static readonly DependencyProperty CountLikeDormProperty =
            DependencyProperty.Register("CountLikeDorm", typeof(int), typeof(ShowDorm), new PropertyMetadata(0));


        public string SizeDorm
        {
            get { return (string)GetValue(SizeDormProperty); }
            set { SetValue(SizeDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SizeDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeDormProperty =
            DependencyProperty.Register("SizeDorm", typeof(string), typeof(ShowDorm), new PropertyMetadata("0"));


        
        private UserProfile owner;


        public BitmapImage ImageOwner
        {
            get { return (BitmapImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("ImageOwner", typeof(BitmapImage), typeof(ShowDorm),new PropertyMetadata(new BitmapImage(new Uri($"../../images/blank_account.png", UriKind.RelativeOrAbsolute))));


        public string NameOwner
        {
            get { return (string)GetValue(NameOwnerProperty); }
            set { SetValue(NameOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameOwnerProperty =
            DependencyProperty.Register("NameOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));



        public string PhoneOwner
        {
            get { return (string)GetValue(PhoneOwnerProperty); }
            set { SetValue(PhoneOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PhoneOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhoneOwnerProperty =
            DependencyProperty.Register("PhoneOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));
        public string AddressOwner
        {
            get { return (string)GetValue(AddressOwnerProperty); }
            set { SetValue(AddressOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddressOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddressOwnerProperty =
            DependencyProperty.Register("AddressOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));



        public string GenderOwner
        {
            get { return (string)GetValue(GenderOwnerProperty); }
            set { SetValue(GenderOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GenderOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GenderOwnerProperty =
            DependencyProperty.Register("GenderOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));

        public ShowDorm(Dorm dorm)
        {
            InitializeComponent();
            TransitioningContentSlide.OnApplyTemplate();
            this.dorm = dorm;
            initDorm();
            initProfile();
        }
        private void initDorm()
        {
            ImageDorm = dorm.Image;
            OwnerDorm = dorm.Owner;
            AddressDorm = dorm.Address;
            DesDorm = dorm.Description;
            PriceDorm = "$"+dorm.Price;
            QualityDorm = dorm.Quality;
            CountDorm = "+"+dorm.Count.ToString();
            WifiDorm = dorm.IsWifi;
            ParkingDorm = dorm.IsParking;
            TelevisionDorm = dorm.IsTelevision;
            BathroomDorm = dorm.IsBathroom;
            AirConditionerDorm = dorm.IsAirCondiditioner;
            WaterHeaterDorm = dorm.IsWaterHeater;
            CountLikeDorm = dorm.CountLike;
            SizeDorm = $"Area: {dorm.Size} m²";
        }

        private void initProfile()
        {
            owner = Mydatabase.getOwnerProfileWithDorm(dorm.Id);
            ImageOwner = Helpers.ConvertByteToImageBitmap(owner.Avatar);
            NameOwner = owner.Name;
            PhoneOwner = owner.Phone;
            AddressOwner = owner.Address;
            lbEmail.Content = owner.Email;
            GenderOwner = Helpers.ConvertByteToGender(owner.Gender);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TransitioningContentSlide.OnApplyTemplate();
            layoutDorm.Children.Clear();
            layoutDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutDorm.Children.Add(new HomeControl());
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            click = !click;
            if (click)
            {
                likeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E34853"));
                CountLikeDorm++;
            }
            else
            {
                likeIcon.Foreground = new SolidColorBrush(Colors.Gray);
                CountLikeDorm--;
            }
        }
    }
}
