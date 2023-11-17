using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace IRPlateModel.Wpf.Converters
{
    public class ValueInvisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ValueEqualityConverter.Compare(value, parameter) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
