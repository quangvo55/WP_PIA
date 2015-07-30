using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace App1.Utils
{    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;

            return String.Format("{0:MMMM dd, yyyy} {0:dddd}", date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class TimespanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            TimeSpan ts = (TimeSpan)value;

            return Math.Floor(ts.TotalHours) + " Hours " + ts.Minutes + " Minutes";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class StringToCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double curr = (double)value;
            return curr.ToString("C");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class CurrencyForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double curr = (double)value;
            return (curr > 0) ? new SolidColorBrush(Colors.Green) : (curr == 0) ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class AlternatingIndexConverter : IValueConverter
    {
        private static int _index;

        public Brush Even { get; set; }
        public Brush Odd { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
             Even = new SolidColorBrush(Color.FromArgb(0xFF, 0x42, 0x8b, 0xca));
             Odd = new SolidColorBrush(Colors.White);
             return (_index++ % 2 == 0) ? Even : Odd;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }



}
