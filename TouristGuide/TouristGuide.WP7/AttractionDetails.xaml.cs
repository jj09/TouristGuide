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
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Device.Location;

namespace First_WPA
{
    public partial class AttractionDetails : PhoneApplicationPage
    {
        WebClient clientAttraction = new WebClient();
        
        public AttractionDetails()
        {
            InitializeComponent();
            attractionHeader.Header = PhoneApplicationService.Current.State["Name"].ToString();             
            String ID =  PhoneApplicationService.Current.State["AttID"].ToString();
            clientAttraction.OpenReadCompleted += new OpenReadCompletedEventHandler(clientAttraction_OpenReadCompleted);
            clientAttraction.OpenReadAsync(new Uri("http://pm.studentlive.pl/WebService/GetAttraction?ID=" + ID), UriKind.Absolute);
        }
        [DataContract]
        public class Details
        {
            [DataMember]
            public string ID { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public string Description { get; set; }

            [DataMember(Name = "Coordinates")]
             public Coordinates coordinatesDet;

            [DataMember(Name = "Address")]
             public Address address;

            [DataMember(Name = "Reviews")]
            public ReviewsDetails[] reviews;

           [DataMember]
           public string Country { get; set; }

           [DataMember]
           public string Images { get; set; }

           [DataMember]
           public string Video { get; set; } 

           [DataMember]
           public string AttractionType { get; set; } 

           [DataMember]
           public double AvgRating { get; set; } 
            
        }

        [DataContract]
        public class ReviewsDetails
        {
            [DataMember]
            public string ID { get; set; }

            [DataMember]
            public string Author { get; set; }

            [DataMember]
            public string Date { get; set; }

            [DataMember]
            public double Rating { get; set; }

            [DataMember]
            public string Text { get; set; }


        }

        [DataContract]
        public class Address
        {
            [DataMember]
            public string ID { get; set; }

            [DataMember]
            public string Region { get; set; }

            [DataMember]
            public string City { get; set; }

            [DataMember]
            public string Country { get; set; }

            [DataMember]
            public string Street { get; set; }

            [DataMember]
            public int BuildingNumber { get; set; }


        }

        [DataContract]
        public class Coordinates
        {
            [DataMember]
            public int ID { get; set; }

            [DataMember]
            public double Latitude { get; set; }

            [DataMember]
            public double Longitude { get; set; }


        }
        [DataContract]
        public class Attraction
        {
            [DataMember(Name = "attraction")]
            public Details details;

        }
        private void addFavorites_Click(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
           // bool isF = ;
            if (settings.Contains("favorites"))
            {
                var k = settings["favorites"].ToString();
               // k += ", " + attTitle.Header;
                
                settings["favorites"] = k.ToString();
            }
            else
            {
               // settings["favorites"] = attTitle.Header;
            }
        }

        private void showMap_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/BingMaps.xaml"), UriKind.Relative));
        }
        void clientAttraction_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var serializer = new DataContractJsonSerializer(typeof(Attraction));
            Attraction ipResult = (Attraction)serializer.ReadObject(e.Result);
            List<Reviews> attractionsReviews = new List<Reviews>(); 
               
                for (int j = 0; j < ipResult.details.reviews.Length - 1; j++)
                {
                    attractionsReviews.Add(new Reviews(ipResult.details.reviews[j].Author,ipResult.details.reviews[j].Date,
                        ipResult.details.reviews[j].Rating,ipResult.details.reviews[j].Text));
                }
                tbDescription.Text = ipResult.details.Description.ToString();
                String lat = ipResult.details.coordinatesDet.Latitude.ToString();
                String lon = ipResult.details.coordinatesDet.Longitude.ToString();
                lat = lat.Replace(".",",");
                lon = lon.Replace(".",",");  
                map1.Center = new GeoCoordinate(double.Parse(lat),double.Parse(lon));
                map1.ZoomBarVisibility = System.Windows.Visibility.Visible;
                lBReviews.ItemsSource = attractionsReviews;
        }
    }
}