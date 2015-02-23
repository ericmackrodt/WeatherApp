using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider.OpenWeatherMap
{
    public class OpenWeatherMapProvider : IWeatherProvider
    {
        private readonly IOpenWeatherMapClient _apiClient;

        public OpenWeatherMapProvider(IOpenWeatherMapClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<BaseWeatherData> GetCurrentWeather(string locationQuery, TemperatureUnit unit)
        {
            var data = await _apiClient.GetWeather(locationQuery, (Units)unit);
            return new WeatherData(data, unit);
        }

        public async Task<BaseWeatherData> GetCurrentWeather(double latitude, double longitude, TemperatureUnit unit)
        {
            var data = await _apiClient.GetWeather(latitude, longitude, (Units)unit);
            return new WeatherData(data, unit);
        }

        public async Task<BaseWeatherData> GetCurrentWeather(int locationId, TemperatureUnit unit)
        {
            var data = await _apiClient.GetWeather(locationId, (Units)unit);
            return new WeatherData(data, unit);
        }

        public SemanticWeatherEnum GetSemanticWeatherEnum(BaseWeatherData data)
        {
            var semantic = new SemanticOpenWeatherMap((WeatherData)data);
            return semantic.GetSemantic();
        }
    }
}
