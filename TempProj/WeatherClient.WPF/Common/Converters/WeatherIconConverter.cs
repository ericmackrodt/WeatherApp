using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WeatherClient.WPF.Common.Converters
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var status = value.ToString();
            var bitmapImage = new BitmapImage(new Uri(string.Format("/Assets/WeatherImages/{0}.png", status), UriKind.Relative));
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
