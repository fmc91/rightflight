using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace RightFlight
{
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int input = (int)value;

            if (input == 0)
                return String.Empty;
            else
                return input.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Int32.TryParse((string)value, out int input))
                return input;
            else
                return 0;
        }
    }
}
