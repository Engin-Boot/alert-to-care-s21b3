using System;
using System.Globalization;
using System.Windows.Data;

namespace Alert_To_Care_Frontend.Converters
{
    class BedStatusToAdmitPatienStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool valueFromSource))
            {
                return !valueFromSource;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

