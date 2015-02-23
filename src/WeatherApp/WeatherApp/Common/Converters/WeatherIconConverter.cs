using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Provider.OpenWeatherMap;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace WeatherApp.Common.Converters
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var data = value as WeatherData;
            if (data == null)
                return null;


            var bitmapImage = new BitmapImage(new Uri(string.Format("ms-appx:///Assets/WeatherIcons/{0}_{1}.png", data.TimeOfDay.ToString(), data.IconType.ToString()), UriKind.Absolute));
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
