using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RightFlight
{
    public partial class HomePage : Page
    {
        public HomePage(HomeViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
