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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using Microsoft.Phone.Shell;

namespace First_WPA
{
    public partial class Page : PhoneApplicationPage
    {
        public Page()
        {
            InitializeComponent();
            
            //map1.ViewChangeEnd += new EventHandler<MapEventArgs>(map1_ViewChangeEnd);
            WebClient client = new WebClient();
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.OpenReadAsync(new Uri("http://pm.studentlive.pl/WebService/GetPlaces?country=Poland&start=0&count=1"), UriKind.Absolute);
            //client.OpenReadAsync(new Uri("http://ws.geonames.org/postalCodeLookupJSON?postalcode=6600&country=AT"), UriKind.Absolute);
            map1.Center = new GeoCoordinate(47.676289396624654, -122.12096571922302);


            map1.ZoomLevel = 10;
            map1.ZoomBarVisibility = System.Windows.Visibility.Visible;
            
           
        }

        void map1_ViewChangeEnd(object sender, MapEventArgs e)
        {

            throw new NotImplementedException();
        }

        [DataContract]
        public class detailedAddress
        {
            [DataMember]
            public int ID { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public string Description { get; set; }

            [DataMember]
            public int Coordinates { get; set; }

            //[DataMember]
            //public string adminName2 { get; set; }

            //[DataMember]
            //public string adminName3 { get; set; }

            //[DataMember]
            //public string countryCode { get; set; }

            //[DataMember]
            //public string placeName { get; set; }

            //[DataMember]
            //public double lat { get; set; }

            //[DataMember]
            //public double lng { get; set; }
        }

        [DataContract]
        public class Postal_Result
        {
            [DataMember(Name = "places")]
            public detailedAddress[] addresses;
        }
        

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
          var serializer = new DataContractJsonSerializer(typeof(Postal_Result));
          Postal_Result ipResult = (Postal_Result)serializer.ReadObject(e.Result);
 
          for (int i = 0; i <= ipResult.addresses.Length - 1; i++)
          {
              //---create a new pushpin---
              Pushpin pin = new Pushpin();

              //---set the location for the pushpin---
              pin.Location = new GeoCoordinate(47.676289396624654 + i, -122.12096571922302 + i);
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
            //---print out the latitude---
            //System.Diagnostics.Debug.WriteLine(ipResult.addresses[i].lat.ToString());
 
            ////---print out the longitude---
            //System.Diagnostics.Debug.WriteLine(ipResult.addresses[i].lng.ToString());
            //System.Diagnostics.Debug.WriteLine("----------");

          }
          map1.ZoomLevel = 10;            
          map1.ZoomBarVisibility = System.Windows.Visibility.Visible;
          
        }

        ImageBrush image = new ImageBrush()
        {
            ImageSource = new System.Windows.Media.Imaging.BitmapImage
            (new Uri("http://www.clker.com/cliparts/e/d/9/9/1206572112160208723johnny_automatic_NPS_map_pictographs_part_67.svg.med.png"))
        };

        void Pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Phone.Controls.Maps.Pushpin tempPP = new Microsoft.Phone.Controls.Maps.Pushpin();

            tempPP = (Microsoft.Phone.Controls.Maps.Pushpin)sender;
            PhoneApplicationService.Current.State["Name"] = tempPP.Name;
            PhoneApplicationService.Current.State["Desc"] = "Perfect attraction";
            NavigationService.Navigate(new Uri(string.Format("/AttractionDetails.xaml"), UriKind.Relative));

            // you can check the tempPP.Content property

        }
    }
}