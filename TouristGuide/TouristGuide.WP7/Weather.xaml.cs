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
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.Phone.Tasks;


using ImageTools.IO.Gif;
using ImageTools;
using GoogleWeatherWP7;
using System.Net.NetworkInformation;
using Microsoft.Phone.Net.NetworkInformation;

namespace First_WPA
{
    public partial class Weather : PhoneApplicationPage
    {
        public string gifImageConstPath = "http://google.com";
        public string gifUrl = "";
        public Weather()
        {
            
            InitializeComponent();
            
           
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
    }
        
}