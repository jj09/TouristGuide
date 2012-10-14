using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TouristGuide.WP7.WPService;
using System.ComponentModel;

namespace TouristGuide.WP7.ViewModels
{
    public class AttractionViewModel : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string ImageUri { get; set; }

        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    NotifyPropertyChanged("Country");
                }
            }
        }

        public string CountryFlagUri { get; set; }

        private string _region;
        public string Region
        {
            get
            {
                return _region;
            }
            set
            {
                if (value != _region)
                {
                    _region = value;
                    NotifyPropertyChanged("Region");
                }
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    NotifyPropertyChanged("City");
                }
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                if (value != _street)
                {
                    _street = value;
                    NotifyPropertyChanged("Street");
                }
            }
        }

        private int? _buildingNumber;
        public int? BuildingNumber
        {
            get
            {
                return _buildingNumber;
            }
            set
            {
                if (value != _buildingNumber)
                {
                    _buildingNumber = value;
                    NotifyPropertyChanged("BuildingNumber");
                }
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        private ObservableCollection<AttractionReview> _reviews;
        public ObservableCollection<AttractionReview> Reviews
        {
            get { return _reviews; }
            set
            {
                if (value != _reviews)
                {
                    _reviews = value;
                    NotifyPropertyChanged("Reviews");
                }
            }
        }

        public void LoadData(int id)
        {
            WPServiceClient WPServiceClient = new WPServiceClient();            
            WPServiceClient.GetAttractionByIdCompleted += new EventHandler<GetAttractionByIdCompletedEventArgs>(WPServiceClient_GetAttractionByIdCompleted);
            WPServiceClient.GetAttractionByIdAsync(id);
        }

        void WPServiceClient_GetAttractionByIdCompleted(object sender, GetAttractionByIdCompletedEventArgs e)
        {
            var attraction = e.Result;
            Id = attraction.ID;
            Name = attraction.Name;
            Country = attraction.Country.Name;
            CountryFlagUri = "..\\Resources\\Icons\\Flags\\" + attraction.Country.Name + ".png";
            Region = attraction.Address.Region;
            City = attraction.Address.City;
            Street = attraction.Address.Street;
            BuildingNumber = attraction.Address.BuildingNumber;
            Description = Regex.Replace(attraction.Description, "<.*?>", string.Empty);
            Reviews = attraction.Reviews;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
