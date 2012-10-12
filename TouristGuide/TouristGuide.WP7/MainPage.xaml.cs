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
using TouristGuide.WP7.ViewModels;

namespace TouristGuide.WP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            infoCanvas.Visibility = App.ViewModel.Attractions.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.Search(searchTextBox.Text.Trim());
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedIndex == -1)
                return;

            int itemId = ((sender as ListBox).SelectedItem as AttractionViewModel).Id;
            NavigationService.Navigate(new Uri(string.Format("/TouristGuide.WP7;component/AttractionPage.xaml?id={0}",itemId),UriKind.Relative));
        }
    }
}