using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WeatherClient.Provider;

namespace WeatherClient.WPF.Common.Converters
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var data = value as WeatherData;
            if (data == null)
                return null;
            var bitmapImage = new BitmapImage(new Uri(string.Format("/Assets/WeatherImages/{0}_{1}.png", data.TimeOfDay.ToString(), data.IconType.ToString()), UriKind.Relative));
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
