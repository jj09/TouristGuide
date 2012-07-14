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
using Microsoft.Phone.Net.NetworkInformation;

namespace First_WPA
{
    public partial class Downloading : PhoneApplicationPage
    {
        WebClient client = new WebClient();
        public Downloading()
        {
            InitializeComponent();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.UserState as string == "mobiforge")
            {
                txtStatus.Text = e.BytesReceived.ToString() + " bytes received.";
            }
        }
        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled) MessageBox.Show(e.Result);
        }
        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
                    WebClient client = new WebClient();
          client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
          client.OpenReadAsync(new Uri("http://ws.geonames.org/postalCodeLookupJSON?postalcode=6600&country=AT"), UriKind.Absolute);   
        }

        private void btnDictionary_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.DictServiceSoapClient ws = new ServiceReference1.DictServiceSoapClient();
            ws.DefineCompleted += new EventHandler<ServiceReference1.DefineCompletedEventArgs>(ws_DefineCompleted);
            ws.DefineAsync("cool");
        }
        void ws_DefineCompleted(object sender, ServiceReference1.DefineCompletedEventArgs e)
        {
            for (int i = 0; i < e.Result.Definitions.Length; i++) MessageBox.Show(e.Result.Definitions[i].WordDefinition);
        }
        [DataContract]
        public class detailedAddress
        {
            [DataMember]
            public string adminCode1 { get; set; }

            [DataMember]
            public string adminCode2 { get; set; }

            [DataMember]
            public string adminCode3 { get; set; }

            [DataMember]
            public string adminName1 { get; set; }

            [DataMember]
            public string adminName2 { get; set; }

            [DataMember]
            public string adminName3 { get; set; }

            [DataMember]
            public string countryCode { get; set; }

            [DataMember]
            public string placeName { get; set; }

            [DataMember]
            public double lat { get; set; }

            [DataMember]
            public double lng { get; set; }
        }

        [DataContract]
        public class Postal_Result
        {
            [DataMember(Name = "postalcodes")]
            public detailedAddress[] addresses;
        }
        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var serializer = new DataContractJsonSerializer(typeof(Postal_Result));
            Postal_Result ipResult = (Postal_Result)serializer.ReadObject(e.Result);

            for (int i = 0; i <= ipResult.addresses.Length - 1; i++)
            {
                //---print out the place name---
                System.Diagnostics.Debug.WriteLine(ipResult.addresses[i].placeName.ToString());
                MessageBox.Show(ipResult.addresses[i].placeName.ToString() + ipResult.addresses[i].lat.ToString());

                //---print out the latitude---
                System.Diagnostics.Debug.WriteLine(ipResult.addresses[i].lat.ToString());

                //---print out the longitude---
                System.Diagnostics.Debug.WriteLine(ipResult.addresses[i].lng.ToString());
                System.Diagnostics.Debug.WriteLine("----------");
            }
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            var ni = NetworkInterface.NetworkInterfaceType;

            System.Diagnostics.Debug.WriteLine("Network Available: " +
            NetworkInterface.GetIsNetworkAvailable());

            if (ni == NetworkInterfaceType.Wireless80211) System.Diagnostics.Debug.WriteLine("Wireless");
            else if (ni == NetworkInterfaceType.None)
                System.Diagnostics.Debug.WriteLine("None");
        }
    }
}