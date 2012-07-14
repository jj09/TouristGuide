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
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace First_WPA
{
    public partial class CountryDescription : PhoneApplicationPage
    {
        WebClient client = new WebClient();
        public CountryDescription()
        {
            InitializeComponent();
            InitializeComponent();
            if (!DeviceNetworkInformation.IsNetworkAvailable)
            {
                ConnectionSettingsTask cst = new ConnectionSettingsTask();
                cst.ConnectionSettingsType = ConnectionSettingsType.WiFi;
                cst.Show();
            }
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.OpenReadAsync(new Uri("http://pm.studentlive.pl/WebService/GetCountry?ID=1"), UriKind.Absolute);
        }
        [DataContract]
        public class Country
        {
            [DataMember]
            public string ID { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public string Description { get; set; }
        }
        [DataContract]
        public class Countries
        {
            [DataMember(Name = "country")]
            public Country countryDetails;

        }

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            //MessageBox.Show(e.Result.);
            var serializer = new DataContractJsonSerializer(typeof(Countries));
            Countries ipResult = (Countries)serializer.ReadObject(e.Result);


            tBDescription.Text = ipResult.countryDetails.Description;

           
        }
    }
}