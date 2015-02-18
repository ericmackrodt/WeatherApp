using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Provider
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly IOpenWeatherMapClient _apiClient;

        public WeatherProvider(IOpenWeatherMapClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<WeatherData> GetCurrentWeather(string locationQuery, TemperatureUnit unit)
        {
            var data = await _apiClient.GetWeather(locationQuery, (Units)unit);
            return new WeatherData(data, unit);
        }

        public async Task<WeatherData> GetCurrentWeather(double latitude, double longitude, TemperatureUnit unit)
        {
            var data = await _apiClient.GetWeather(latitude, longitude, (Units)unit);
            return new WeatherData(data, unit);
        }

        public async Task<WeatherData> GetCurrentWeather(int locationId, TemperatureUnit unit)
        {
            var data = await _apiClient.GetWeather(locationId, (Units)unit);
            return new WeatherData(data, unit);
        }

        public SemanticWeatherEnum GetSemanticWeatherEnum(WeatherData data)
        {
            throw new NotImplementedException();
        }
    }
}
