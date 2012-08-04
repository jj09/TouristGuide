using System;
using System.Net;
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
            Description = attraction.Description;
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
