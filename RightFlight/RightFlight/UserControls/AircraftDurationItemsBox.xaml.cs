using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RightFlight
{
    public partial class AircraftDurationItemsBox : UserControl
    {
        public AircraftDurationItemsBox()
        {
            InitializeComponent();
        }

        public string AircraftSearchText { get; set; } 

        public AircraftDuration AircraftDurationToAdd { get; set; }

        public IEnumerable AircraftDurations
        {
            get { return (IEnumerable)GetValue(AircraftDurationsProperty); }
            set { SetValue(AircraftDurationsProperty, value); }
        }

        public static readonly DependencyProperty AircraftDurationsProperty =
            DependencyProperty.Register(nameof(AircraftDurations), typeof(IEnumerable), typeof(AircraftDurationItemsBox), new PropertyMetadata(defaultValue: null));


    }
}
