using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WordCounter.Utilities
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool input)
            {
                return input ? Visibility.Collapsed : Visibility.Visible;
            }

            return default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
