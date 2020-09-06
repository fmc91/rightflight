using RightFlightBusinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace RightFlight
{
    public class NationalityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NationalityInfo input = (NationalityInfo)value;

            return input?.NationalityId ?? -1;
        }
    }
}
