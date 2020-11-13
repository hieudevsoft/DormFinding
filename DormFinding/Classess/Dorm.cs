using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DormFinding { 
    public class Dorm
    {
        private int _id;
        private String _owner;
        private String _address;
        private String _description;
        private double _price;
        private double _sale;
        private BitmapImage _image;
        private int _review;
        private int _quality;
        private int _count;
        private int _countLike;
        private bool _isWifi;
        private bool _isParking;
        private bool _isTelevision;
        private bool _isBathroom;
        private bool _isAirCondidition;
        private bool _isEHeater;
        private bool _isSpaceClothes;

        public string Owner { get => _owner; set => _owner = value; }
        public string Address { get => _address; set => _address = value; }
        public string Description { get => _description; set => _description = value; }
        public double Price { get => _price; set => _price = value; }
        public int Review { get => _review; set => _review = value; }
        public int Count { get => _count; set => _count = value; }
        public int CountLike { get => _countLike; set => _countLike = value; }
        public bool IsWifi { get => _isWifi; set => _isWifi = value; }
        public bool IsParking { get => _isParking; set => _isParking = value; }
        public bool IsTelevision { get => _isTelevision; set => _isTelevision = value; }
        public bool IsBathroom { get => _isBathroom; set => _isBathroom = value; }
        public bool IsAirCondidition { get => _isAirCondidition; set => _isAirCondidition = value; }
        public bool IsEHeater { get => _isEHeater; set => _isEHeater = value; }
        public bool IsSpaceClothes { get => _isSpaceClothes; set => _isSpaceClothes = value; }
        public int Id { get => _id; set => _id = value; }
        public BitmapImage Image { get => _image; set => _image = value; }
        public int Quality { get => _quality; set => _quality = value; }
        public double Sale { get => _sale; set => _sale = value; }

        public Dorm()
        {

        }

        public Dorm(
            int id,
            string owner,
            string address,
            string description,
            double price,
            double sale,
            BitmapImage image,
            int review,
            int quality,
            int count, 
            int countLike, 
            bool isWifi, 
            bool isParking, 
            bool isTelevision,
            bool isBathroom, 
            bool isAirCondidition,
            bool isEHeater, 
            bool isSpaceClothes )
            
        {
            Id = id;
            Owner = owner;
            Address = address;
            Description = description;
            Price = price;
            Sale = _sale;
            Image = image;
            Review = review;
            Quality = quality;
            Count = count;
            CountLike = countLike;
            IsWifi = isWifi;
            IsParking = isParking;
            IsTelevision = isTelevision;
            IsBathroom = isBathroom;
            IsAirCondidition = isAirCondidition;
            IsEHeater = isEHeater;
            IsSpaceClothes = isSpaceClothes;
            Owner = owner;
            Address = address;
            Description = description;
            Price = price;
            Review = review;
            Count = count;
            CountLike = countLike;
            IsWifi = isWifi;
            IsParking = isParking;
            IsTelevision = isTelevision;
            IsBathroom = isBathroom;
            IsAirCondidition = isAirCondidition;
            IsEHeater = isEHeater;
            IsSpaceClothes = isSpaceClothes;
            Id = id;
        }
    }
}
