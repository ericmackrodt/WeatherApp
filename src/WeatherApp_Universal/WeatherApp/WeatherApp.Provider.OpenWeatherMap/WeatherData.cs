using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Provider.Helpers;

namespace WeatherApp.Provider.OpenWeatherMap
{
    public class WeatherData : BaseWeatherData
    {
        public WeatherConditionCode WeatherID { get; set; }

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
                ImageID = weather.Icon;
            }

            Temperature = Math.Round(data.Main.Temperature, 1);
            Humidity = data.Main.Humidity;
            MinTemperature = Math.Round(data.Main.MinTemperature, 1);
            MaxTemperature = Math.Round(data.Main.MaxTemperature, 1);

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

            var semantic = new OWMWeatherTypeConverter(this);
            ConditionType = semantic.GetSemantic();
        }
    }
}
