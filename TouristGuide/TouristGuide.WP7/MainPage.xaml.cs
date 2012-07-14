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
using System.Runtime.Serialization.Json;

namespace First_WPA
{
    public partial class MainPage : PhoneApplicationPage
    {
        WebClient clientLogin = new WebClient();

        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            Button b = sender as Button;

            int col = Grid.GetColumn(b);
            int row = Grid.GetRow(b);

            if (col == row)
            {
                Grid.SetColumn(b, ++col % 2);
            }
            else
            {
                Grid.SetRow(b, ++row % 2);
            }
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            clientLogin.OpenReadCompleted += new OpenReadCompletedEventHandler(clientLogin_OpenReadCompleted);
            clientLogin.OpenReadAsync(new Uri("http://localhost:23790/WebService/MobileLogOn?user=" + tbLogin.Text + "&pass=" + passwordBox1.Password), UriKind.Absolute);
            
            //string urlWIthData = string.Format("/Main.xaml?name={0}", tbLogin.Text);
            //this.NavigationService.Navigate(new Uri(urlWIthData, UriKind.Relative));

        }

        void clientLogin_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            string userId = e.Result.ToString();
            if(Int32.Parse(userId)!=-1)
                NavigationService.Navigate(new Uri(string.Format("/PanoramicMain.xaml"), UriKind.Relative));
            //var serializer = new DataContractJsonSerializer(typeof(Attraction));
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nie mam czasu!! " );
        }

       

        

       
    }
}