using System;
using Windows.UI.Xaml.Data;

namespace App1.Utils
{
    public class TimespanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            TimeSpan ts = (TimeSpan)value;

            return ts.ToHHMMString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
