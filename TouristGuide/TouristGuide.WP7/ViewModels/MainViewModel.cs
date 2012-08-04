using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using TouristGuide.WP7.ViewModels;
using TouristGuide.WP7.WPService;


namespace TouristGuide.WP7
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Attractions = new ObservableCollection<AttractionViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<AttractionViewModel> Attractions { get; set; }

        private string _infoText = "";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string InfoText
        {
            get
            {
                return _infoText;
            }
            set
            {
                if (value != _infoText)
                {
                    _infoText = value;
                    NotifyPropertyChanged("InfoText");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // load data from WPService

            WPServiceClient WPServiceClient = new WPServiceClient();
            WPServiceClient.GetAttractionsCompleted += new EventHandler<GetAttractionsCompletedEventArgs>(WPServiceClient_GetAttractionsCompleted);
            WPServiceClient.GetAttractionsAsync(null, 0, 20);

            this.IsDataLoaded = true;
        }

        void WPServiceClient_GetAttractionsCompleted(object sender, GetAttractionsCompletedEventArgs e)
        {
            SaveAttractionsData(e.Result);
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

        public void Search(string inputText)
        {
            WPServiceClient WPServiceClient = new WPServiceClient();
            WPServiceClient.SearchAttractionsCompleted += new EventHandler<SearchAttractionsCompletedEventArgs>(WPServiceClient_SearchAttractionsCompleted);
            WPServiceClient.SearchAttractionsAsync(inputText, 0, 20);
        }

        void WPServiceClient_SearchAttractionsCompleted(object sender, SearchAttractionsCompletedEventArgs e)
        {
            SaveAttractionsData(e.Result);
        }

        private void SaveAttractionsData(ObservableCollection<Attraction> observableCollection)
        {
            Attractions.Clear();
            foreach (var attraction in observableCollection)
            {
                Attractions.Add(new AttractionViewModel { Id = attraction.ID, 
                    Name = attraction.Name, 
                    Country = attraction.Country.Name
                });
            }
            InfoText = Attractions.Count > 0 ? "" : "No attractions found.";
        }
    }
}