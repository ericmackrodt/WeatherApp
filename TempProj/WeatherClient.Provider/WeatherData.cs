using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherClient.Provider.Helpers;

namespace WeatherClient.Provider
{
    public class WeatherData
    {
        public string CityID { get; set; }

        public string CityName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public WeatherConditionCode WeatherID { get; set; }

        public string WeatherMain { get; set; }

        public string WeatherDescription { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double MinTemperature { get; set; }

        public double MaxTemperature { get; set; }

        public DateTime Date { get; set; }
        
        public DateTime Sunrise { get; set; }
        
        public DateTime Sunset { get; set; }

        public double WindSpeed { get; set; }

        public WeatherIconType IconType { get; set; }

        public TemperatureUnit TemperatureUnit { get; set; }

        public WeatherData() { }

        public WeatherData(CurrentWeatherData data, TemperatureUnit unit)
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
