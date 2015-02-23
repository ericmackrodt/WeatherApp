using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
    public abstract class BaseWeatherData
    {
        protected ApparentTemperatureCalculator _apparentTemperatureCalc;

        public string CityID { get; set; }

        public string CityName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

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

        public TimeOfDay TimeOfDay
        {
            get
            {
                var now = DateTime.Now;
                return now >= Sunrise && now < Sunset ? TimeOfDay.Day : TimeOfDay.Night;
            }
        }

        public double FeelsLikeTemperature
        {
            get
            {
                return _apparentTemperatureCalc.GetApparentWeather();
            }
        }
    }
}
