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
using System.Windows.Navigation;

namespace First_WPA
{
    public partial class Maps : PhoneApplicationPage
    {
        public Maps()
        {
            InitializeComponent();
            if (NavigationContext.QueryString["val"].Length > 0)
                MessageBox.Show(NavigationContext.QueryString["val"], "Data Passed", MessageBoxButton.OK);
            else
                MessageBox.Show("{Empty}!", "Data Passed", MessageBoxButton.OK);
        }
        
    }
}