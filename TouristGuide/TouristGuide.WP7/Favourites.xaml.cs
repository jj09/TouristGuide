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
using System.Diagnostics; //---for Debug.WriteLine()---
using System.Device.Location;
using System.IO.IsolatedStorage;

namespace First_WPA
{

    public partial class Favourites : PhoneApplicationPage
    {
        public Favourites()
        {
            InitializeComponent();
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("favorites"))
            {
                var location = settings["favorites"].ToString();
                MessageBox.Show(location.ToString());
            }
        }
            
    }
}