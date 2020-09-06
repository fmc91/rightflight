using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RightFlight
{
    public partial class BookFlightPage : Page
    {
        public BookFlightPage(BookFlightViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
