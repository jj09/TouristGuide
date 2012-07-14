using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
//using System.Net.NetworkInformation;
using Microsoft.Phone.Controls;
using System.Diagnostics; //---for Debug.WriteLine()---
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Tasks;
using First_WPA.ServiceReference1;

namespace First_WPA
{
    public partial class BingMaps : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;
        public BingMaps()
        {
            InitializeComponent();
            if (!InternetIsAvailable())
            {
                //Service1Client objClient = new Service1Client();
                //objClient.WiFiCompleted += new EventHandler<WiFiCompletedEventArgs>(WIFiCall);
                //objClient.WiFiAsync();
                ConnectionSettingsTask task = new ConnectionSettingsTask();
                task.ConnectionSettingsType = ConnectionSettingsType.WiFi;
                task.Show();
            }
            if (watcher == null)
            {
                //---get the highest accuracy---
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High)
                {
                    //---the minimum distance (in meters) to travel before the next 
                    // location update---
                    MovementThreshold = 10
                };

                //---event to fire when a new position is obtained---
                watcher.PositionChanged += new
                EventHandler<GeoPositionChangedEventArgs
                <GeoCoordinate>>(watcher_PositionChanged);

                //---event to fire when there is a status change in the location 
                // service API---
                watcher.StatusChanged += new
                EventHandler<GeoPositionStatusChangedEventArgs>
                (watcher_StatusChanged);
                watcher.Start();
            }
            map1.Center = new GeoCoordinate(47.676289396624654, -122.12096571922302);
            map1.ZoomBarVisibility = System.Windows.Visibility.Visible;
           
            map1.ZoomLevel = 15;
            for (int i = 0; i < 10; i++)
            {

                //---create a new pushpin---
                Pushpin pin = new Pushpin();

                //---set the location for the pushpin---
                pin.Location = new GeoCoordinate(47.676289396624654+i, -122.12096571922302+i);

                //---add the pushpin to the map---

                pin.Content = new Ellipse()
                {
                    Fill = image,

                    StrokeThickness = 10,
                    Height = 100,
                    Width = 100
                };
                pin.MouseLeftButtonUp += new MouseButtonEventHandler(Pushpin_MouseLeftButtonUp);

                //---add the pushpin to the map---
                map1.Children.Add(pin);
            }
        }
        

        ImageBrush image = new ImageBrush()
        {
            ImageSource = new System.Windows.Media.Imaging.BitmapImage
                              (new Uri("http://www.clker.com/cliparts/e/d/9/9/1206572112160208723johnny_automatic_NPS_map_pictographs_part_67.svg.med.png"))
        };
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            switch (menuItem.Header.ToString())
            {
                case "Satelite View": map1.Mode = new Microsoft.Phone.Controls.Maps.AerialMode();
                    break;
                case "Street View": map1.Mode = new Microsoft.Phone.Controls.Maps.RoadMode();
                    break;
                    
            }
            //MessageBox.Show("You chose to  " + menuItem.Header.ToString(), "Result", MessageBoxButton.OK);
        }
        void Pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Microsoft.Phone.Controls.Maps.Pushpin tempPP = new Microsoft.Phone.Controls.Maps.Pushpin();

            //tempPP = (Microsoft.Phone.Controls.Maps.Pushpin)sender;
            NavigationService.Navigate(new Uri(string.Format("/PanoramaPage1.xaml"), UriKind.Relative));

            // you can check the tempPP.Content property

        }
        private bool InternetIsAvailable()
        {

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("No internet connection is available.  Try again later.");
                
                return false;
            }
            return true;
        }
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
          switch (e.Status)
          {
            case GeoPositionStatus.Disabled:
            Debug.WriteLine("disabled");
            break;
            case GeoPositionStatus.Initializing:
            Debug.WriteLine("initializing");
            break;
            case GeoPositionStatus.NoData:
            Debug.WriteLine("nodata");
            break;
            case GeoPositionStatus.Ready:
            Debug.WriteLine("ready");
            break;
           }
        }
        
        void watcher_PositionChanged(object sender,GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Debug.WriteLine("({0},{1})", 
            e.Position.Location.Latitude, e.Position.Location.Longitude);
 
            map1.Center = new GeoCoordinate(
            e.Position.Location.Latitude, e.Position.Location.Longitude);
        }
       

    }
}