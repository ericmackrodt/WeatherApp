using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Provider;
using Windows.UI.Xaml.Data;

namespace WeatherApp.Common.Converters
{
    public class TemperatureUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var v = (TemperatureUnit)value;
            if (v == TemperatureUnit.Celsius)
                return "°C";

            return "°F";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
