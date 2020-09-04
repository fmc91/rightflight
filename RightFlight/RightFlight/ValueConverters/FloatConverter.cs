using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace RightFlight
{
    public class FloatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float input = (float)value;

            if (input == 0)
                return String.Empty;
            else
                return input.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Single.TryParse((string)value, out float input))
                return input;
            else
                return 0;
        }
    }
}
