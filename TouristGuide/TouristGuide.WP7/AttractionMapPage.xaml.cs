using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using TouristGuide.WP7.Models;
using TouristGuide.WP7.ViewModels;

namespace TouristGuide.WP7
{
    public partial class AttractionMapPage : INotifyPropertyChanged
    {
        private AttractionViewModel viewModel = new AttractionViewModel();

        private readonly ObservableCollection<PushpinModel> _pushpins = new ObservableCollection<PushpinModel>
        {
            new PushpinModel
            {
                Location = DefaultLocation,
                Icon = new Uri("/Resources/Icons/Pushpins/PushpinLocation.png", UriKind.Relative)
            }
        };

        public ObservableCollection<PushpinModel> Pushpins
        {
            get { return _pushpins; }
        }

        /// <value>Default location coordinate.</value>
        private static readonly GeoCoordinate DefaultLocation = new GeoCoordinate(47.639631, -122.127713);

        #region Consts

        /// <value>Default map zoom level.</value>
        private const double DefaultZoomLevel = 18.0;

        /// <value>Maximum map zoom level allowed.</value>
        private const double MaxZoomLevel = 21.0;

        /// <value>Minimum map zoom level allowed.</value>
        private const double MinZoomLevel = 1.0;

        #endregion

        public AttractionMapPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            //DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(PhoneApplicationPage_Loaded);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string idString = "";
            if (NavigationContext.QueryString.TryGetValue("id", out idString))
            {
                int id = 0;
                int.TryParse(idString, out id);
                viewModel.LoadData(id);
                //webBrowserDescription.NavigateToString(viewModel.Description);
            }
        }

        private readonly CredentialsProvider _credentialsProvider = new ApplicationIdCredentialsProvider(App.Id);

        public CredentialsProvider CredentialsProvider
        {
            get { return _credentialsProvider; }
        }

        private double _zoom;

        public double Zoom
        {
            get { return _zoom; }
            set
            {
                var coercedZoom = Math.Max(MinZoomLevel, Math.Min(MaxZoomLevel, value));
                if (_zoom != coercedZoom)
                {
                    _zoom = value;
#warning should be deleted (Two way binding doenst work properly)
                    AttractionMap.ZoomLevel = _zoom;

                    NotifyPropertyChanged("Zoom");
                }
            }
        }

        #region Property Changed

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion

        private void mapTypeSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            if (AttractionMap.Mode is AerialMode)
            {
                AttractionMap.Mode = new RoadMode();
                mapTypeSwitchButton.Content = "Aerial";
            }
            else
            {
                AttractionMap.Mode = new AerialMode(true);
                mapTypeSwitchButton.Content = "Road";
            }
        }

        private void ButtonZoomIn_Click(object sender, RoutedEventArgs e)
        {
            Zoom += 1;
        }

        private void ButtonZoomOut_Click(object sender, RoutedEventArgs e)
        {
            Zoom -= 1;
        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            if (myPositionCheckBox.IsChecked == true)
            {
                using (var watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default))
                {
                    var location = watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
                    if (!location)
                    {
                        watcher.Position.Location.Latitude = 15;
                        watcher.Position.Location.Longitude = 15;
                    }
                    var myLocation = new Pushpin();
                    myLocation.Location = watcher.Position.Location;
                    AttractionMap.Children.Add(myLocation);
                }

            }

        }
    }
}