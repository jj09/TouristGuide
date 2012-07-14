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
using Coding4Fun.Phone.Controls;
using System.Windows.Media.Imaging;


namespace First_WPA
{
    public partial class Main : PhoneApplicationPage
    {
        
        public Main()
        {
            InitializeComponent();
            //string dk = this.NavigationContext.QueryString["name"].ToString();
            //var toast = new ToastPrompt
            //{
            //    Title = "Welcome",
            //    Message = dk,
            //    ImageSource = new BitmapImage(new Uri("..\\ApplicationIcon.png", UriKind.RelativeOrAbsolute))
            //};
            //toast.Show();
        }   
        

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/Page2.xaml"), UriKind.Relative));

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
            NavigationService.Navigate(new Uri(string.Format("/JSON1.xaml"), UriKind.Relative));
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
            NavigationService.Navigate(new Uri(string.Format("/Invite.xaml"), UriKind.Relative));
            
        }
        
    }
}