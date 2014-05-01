﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PlateModel.Wpf.Converters
{
    public class ValueVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ValueEqualityConverter.Compare(value, parameter) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}