using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace RightFlight
{
    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan input = (TimeSpan)value;

            string result = $"{input.Hours} hours {input.Minutes} minutes";

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
