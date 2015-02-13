using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Provider
{
    public class SemanticWeather
    {
        private WeatherData _weather;
        private TemperatureUnit _temperatureUnit;

        public SemanticWeather(WeatherData weather, TemperatureUnit temperatureUnit)
        {
            _weather = weather;
            _temperatureUnit = temperatureUnit;
        }

        public SemanticWeatherEnum GetSemantic()
        {
            return SemanticWeatherEnum.Clear_Nice;
        }
    }
}
