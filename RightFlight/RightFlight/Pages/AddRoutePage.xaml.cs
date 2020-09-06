using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RightFlight
{
    public partial class AddRoutePage : Page
    {
        public AddRoutePage(AddRouteViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }

        public void AirlineTextChanged(object sender, RoutedEventArgs e)
        {
            ((AddRouteViewModel)DataContext).AirlineSearch();
        }

        public void OriginTextChanged(object sender, RoutedEventArgs e)
        {
            ((AddRouteViewModel)DataContext).OriginSearch();
        }

        public void DestinationTextChanged(object sender, RoutedEventArgs e)
        {
            ((AddRouteViewModel)DataContext).DestinationSearch();
        }

        public void AircraftTextChanged(object sender, RoutedEventArgs e)
        {
            ((AddRouteViewModel)DataContext).AircraftSearch();
        }
    }
}
