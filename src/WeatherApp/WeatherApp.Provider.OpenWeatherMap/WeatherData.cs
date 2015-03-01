using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Provider.Helpers;
using WeatherApp.Provider.OpenWeatherMap.Helpers;

namespace WeatherApp.Provider.OpenWeatherMap
{
    public class WeatherData : BaseWeatherData
    {
        public WeatherConditionCode WeatherID { get; set; }

        public override SemanticWeatherEnum SemanticWeather
        {
            get
            {
                var semantic = new SemanticOpenWeatherMap(this);
                return semantic.GetSemantic();
            }
        }

        public WeatherData()
        {
            _apparentTemperatureCalc = new ApparentTemperatureCalculator(this, SpeedUnit.Ms);
        }

        public WeatherData(CurrentWeatherData data, TemperatureUnit unit)
            : this()
        {
            TemperatureUnit = unit;
            CityID = data.Id;
            Date = int.Parse(data.Dt).UnixTimeToDateTime();
            CityName = data.Name;
            Latitude = data.Coordinates.Latitude;
            Longitude = data.Coordinates.Longitude;
            var weather = data.Weather.FirstOrDefault();
            if (weather != null)
            {
                WeatherID = weather.Id;
                WeatherMain = weather.Main;
                WeatherDescription = weather.Description;
                IconType = weather.ToWeatherIconType();
            }

            Temperature = data.Main.Temperature;
            Humidity = data.Main.Humidity;
            MinTemperature = data.Main.MinTemperature;
            MaxTemperature = data.Main.MaxTemperature;

            var sys = data.Sys;
            if (sys != null)
            {
                Sunrise = sys.Sunrise.UnixTimeToDateTime();
                Sunset = sys.Sunset.UnixTimeToDateTime();
            }

            var wind = data.Wind;
            if (wind != null)
            {
                WindSpeed = wind.Speed;
            }
        }
    }
}
