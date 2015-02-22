using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
    public interface IWeatherProvider
    {
        Task<BaseWeatherData> GetCurrentWeather(string locationQuery, TemperatureUnit unit);
        Task<BaseWeatherData> GetCurrentWeather(double latitude, double longitude, TemperatureUnit unit);
        Task<BaseWeatherData> GetCurrentWeather(int locationId, TemperatureUnit unit);
        SemanticWeatherEnum GetSemanticWeatherEnum(BaseWeatherData data);
    }
}
