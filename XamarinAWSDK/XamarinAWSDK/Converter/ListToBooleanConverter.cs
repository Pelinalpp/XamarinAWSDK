using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinAWSDK.Converter
{
    public class ListToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = value != null && value is IList list && list.Count > 0;

            return "0".Equals(parameter) ? b : !b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
