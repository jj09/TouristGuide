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
using Microsoft.Phone.Controls;
using ImageTools.IO.Gif;
using ImageTools;
using GoogleWeatherWP7;
using System.Net.NetworkInformation;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Tasks;
using System.Xml.Linq;
using System.Device.Location;
using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Shell;

namespace First_WPA
{
    public partial class PanoramicMain : PhoneApplicationPage
    {
        public string gifImageConstPath = "http://google.com";
        public string gifUrl = "";
        GeoCoordinateWatcher watcher;
        public PanoramicMain()
        {

           
            InitializeComponent();
            if (!DeviceNetworkInformation.IsNetworkAvailable)
            {
                ConnectionSettingsTask cst = new ConnectionSettingsTask();
                cst.ConnectionSettingsType = ConnectionSettingsType.WiFi;
                cst.Show();
            }
            WebClient client = new WebClient();
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

            map1.Center = new GeoCoordinate(51.10955, 17.037048);
            map1.ZoomBarVisibility = System.Windows.Visibility.Visible;
            String lat = map1.Center.Latitude.ToString();
            String lon = map1.Center.Longitude.ToString();
            lat = lat.Replace(",",".");
            lon = lon.Replace(",",".");         

            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.OpenReadAsync(new Uri("http://pm.studentlive.pl/WebService/GetAttractionsByLatLng?lat="+lat+"&lng="+lon), UriKind.Absolute);

            map1.ZoomLevel = 12;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!DeviceNetworkInformation.IsNetworkAvailable)
            {
                ConnectionSettingsTask cst = new ConnectionSettingsTask();
                cst.ConnectionSettingsType = ConnectionSettingsType.WiFi;
                cst.Show();
            }
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webclient_DownloadStringCompleted);

            webclient.DownloadStringAsync(new Uri("http://www.google.com/ig/api?weather=" + locationTextBox.Text)); // weather location 

            CurrentWeather.Text = locationTextBox.Text + " weather forecast";
        }
        void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("error");

            }


            listBox1.Items.Clear();


            XElement XmlWeather = XElement.Parse(e.Result);

            foreach (var item in XmlWeather.Descendants("forecast_conditions"))
            {
                WeatherInfo rssMain = new WeatherInfo();
                rssMain.day_of_week = (string)item.Element("day_of_week").Attribute("data").Value;
                rssMain.high = (string)item.Element("high").Attribute("data").Value;
                rssMain.low = (string)item.Element("low").Attribute("data").Value;
                rssMain.condition = (string)item.Element("condition").Attribute("data").Value;
                //rssMain.temp_c = (string)item.Element("temp_c").Attribute("data").Value;

                // gif conversion
                ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
                ImageTools.ExtendedImage image = new ImageTools.ExtendedImage();
                gifUrl = gifImageConstPath + (string)item.Element("icon").Attribute("data").Value;
                image.UriSource = new Uri(gifUrl, UriKind.Absolute);
                rssMain.icon = image;


                listBox1.Items.Add(rssMain);
            }



        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/About.xaml"), UriKind.Relative));

        }
        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/BingMaps.xaml?val={0}", "Hellllo"), UriKind.Relative));
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/Weather.xaml"), UriKind.Relative));
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/Help.xaml"), UriKind.Relative));
            // MessageBox.Show(this.NavigationContext.QueryString["name"].ToString(), "Info", MessageBoxButton.OK);
        }
        private void im(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(this.NavigationContext.QueryString["name"].ToString(), "Info", MessageBoxButton.OK);
        }

        private void btnAttractions_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/Attractions.xaml"), UriKind.Relative));
        }

        private void btnMeeting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/JSON1.xaml"), UriKind.Relative));

        }
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Debug.WriteLine("({0},{1})",
            e.Position.Location.Latitude, e.Position.Location.Longitude);

            map1.Center = new GeoCoordinate(
            e.Position.Location.Latitude, e.Position.Location.Longitude);
            
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

        [DataContract]
        public class detailedAddress
        {
            [DataMember]
            public int ID { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember(Name = "Coordinates")]
            
            public detailedCoordinates attCordinates;

            
        }
        [DataContract]
        public class detailedCoordinates
        {
            [DataMember]
            public int ID { get; set; }

            [DataMember]
            public double Latitude { get; set; }

            [DataMember]
            public double Longitude { get; set; }


        }


        [DataContract]
        public class Attractions
        {
            [DataMember(Name = "attractions")]
            public detailedAddress[] addresses;
        }

        

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var serializer = new DataContractJsonSerializer(typeof(Attractions));
            Attractions ipResult = (Attractions)serializer.ReadObject(e.Result);

            for (int i = 0; i <= ipResult.addresses.Length - 1; i++)
            {
                
                //---create a new pushpin---
                Pushpin pin = new Pushpin();

                //---set the location for the pushpin---
                pin.Location = new GeoCoordinate(ipResult.addresses[i].attCordinates.Latitude, ipResult.addresses[i].attCordinates.Longitude);
                pin.Name = ipResult.addresses[i].Name.ToString();

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
            ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("http://www.clker.com/cliparts/e/d/9/9/1206572112160208723johnny_automatic_NPS_map_pictographs_part_67.svg.med.png"))
        };
        void Pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Phone.Controls.Maps.Pushpin tempPP = new Microsoft.Phone.Controls.Maps.Pushpin();

            tempPP = (Microsoft.Phone.Controls.Maps.Pushpin)sender;
            PhoneApplicationService.Current.State["Name"] = tempPP.Name;
            PhoneApplicationService.Current.State["AttID"] = "1";
            NavigationService.Navigate(new Uri(string.Format("/AttractionDetails.xaml"), UriKind.Relative));

            // you can check the tempPP.Content property

        }
    }
}