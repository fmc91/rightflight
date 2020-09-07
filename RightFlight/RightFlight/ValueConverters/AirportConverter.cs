using RightFlightBusinessLayer;
using System;
using System.Globalization;
using System.Windows.Data;

namespace RightFlight
{
    public class AirportConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AirportInfo airport = (AirportInfo)value;
            string strParameter = parameter as string;

            if (strParameter == "code")
                return $"{airport.Name} ({airport.IataAirportCode})";
            else
                return airport.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
