using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Provider
{
    public interface IWeatherProvider
    {
        Task<WeatherData> GetCurrentWeather(string locationQuery, TemperatureUnit unit);
        Task<WeatherData> GetCurrentWeather(double latitude, double longitude, TemperatureUnit unit);
        Task<WeatherData> GetCurrentWeather(int locationId, TemperatureUnit unit);
        double GetApparentTemperature(WeatherData data);
        SemanticWeatherEnum GetSemanticWeatherEnum(WeatherData data);
    }
}
