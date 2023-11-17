using System;
using System.Globalization;
using System.Windows.Data;

namespace IRPlateModel.Wpf.Converters
{
    public class ValueEqualityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Compare(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static bool Compare(object value, object parameter)
        {
            if (parameter != null)
            {
                string p = parameter.ToString();
                if (p.StartsWith("<="))
                    return ((int)value <= int.Parse(p.Substring(2)));
                else if (p.StartsWith(">="))
                    return ((int)value >= int.Parse(p.Substring(2)));
                else if (p.StartsWith("<"))
                    return ((int)value < int.Parse(p.Substring(1)));
                else if (p.StartsWith(">"))
                    return ((int)value > int.Parse(p.Substring(1)));
                else if (p.StartsWith("%"))
                    return (((int)value % int.Parse(p.Substring(1))) == 0);
                else if (p.StartsWith("!%"))
                    return (((int)value % int.Parse(p.Substring(2))) != 0);
                else if (p.StartsWith("!="))
                    return !(value.ToString().Equals(p.Substring(2)));
                else if (p.StartsWith("=="))
                    return (value.ToString().Equals(p.Substring(2)));

                else
                    return value.ToString().Equals(p);
            }
            else
                return value.ToString().Equals("");

        }
    }
}
