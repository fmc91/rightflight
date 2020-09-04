using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RightFlight
{
    public partial class AddFlightPage : Page
    {
        public AddFlightPage()
        {
            InitializeComponent();
        }

        private void AirlineTextChanged(object sender, RoutedEventArgs e)
        {
            ((AddFlightViewModel)DataContext).AirlineSearch();
        }

        private void AirportTextChanged(object sender, RoutedEventArgs e)
        {
            ((AddFlightViewModel)DataContext).AirportSearch();
        }
    }
}
