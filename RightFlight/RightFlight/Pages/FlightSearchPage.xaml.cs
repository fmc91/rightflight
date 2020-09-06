using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RightFlight
{
    public partial class FlightSearchPage : Page
    {
        public FlightSearchPage(FlightSearchViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }

        private void OriginEntryTextChanged(object sender, RoutedEventArgs e)
        {
            ((FlightSearchViewModel)DataContext).OriginCitySearch();
        }

        private void DestinationEntryTextChanged(object sender, RoutedEventArgs e)
        {
            ((FlightSearchViewModel)DataContext).DestinationCitySearch();
        }
    }
}
