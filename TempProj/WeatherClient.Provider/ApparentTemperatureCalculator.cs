using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Provider
{
    //http://www.srh.noaa.gov/epz/?n=wxcalc
    public class ApparentTemperatureCalculator
    {
        private WeatherData _weather;
        private SpeedUnit _speedUnit;

        public ApparentTemperatureCalculator(WeatherData weather, SpeedUnit speedUnit)
        {
            _weather = weather;
            _speedUnit = speedUnit;
        }

        //http://www.meteor.iastate.edu/~ckarsten/bufkit/apparent_temperature.html
        public double GetWindChill()
        {
            var wind = WindToMilesPerHour(_weather.WindSpeed, _speedUnit);
            var t = ConvertTemperature(_weather.Temperature, _weather.TemperatureUnit, TemperatureUnit.Fahrenheit);

            if (t > 40.0)
                return _weather.Temperature;

            var windChill = 35.74 + (0.6215 * t) - (35.75 * Math.Pow(wind, 0.16)) +
                (0.4275 * t * Math.Pow(wind, 0.16));

            var result = ConvertTemperature(windChill, TemperatureUnit.Fahrenheit, _weather.TemperatureUnit);
            return Math.Round(result, 1);
        }

        public double GetHeatIndex()
        {
            var rh = _weather.Humidity;
            var t = ConvertTemperature(_weather.Temperature, _weather.TemperatureUnit, TemperatureUnit.Fahrenheit);

            if (t < 80.0)
                return _weather.Temperature;

            var hi = -42.379 + (2.04901523 * t) + (10.14333127 * rh) -
                (0.22475541 * t * rh) - (6.83783 * Math.Pow(10, -3) * Math.Pow(t, 2)) -
                (5.481717 * Math.Pow(10, -2) * Math.Pow(rh, 2)) + (1.22874 * Math.Pow(10, -3) * Math.Pow(t, 2) * rh) +
                (8.5282 * Math.Pow(10, -4) * t * Math.Pow(rh, 2)) - (1.99 * Math.Pow(10, -6) * Math.Pow(t, 2) * Math.Pow(rh, 2));

            var result = ConvertTemperature(hi, TemperatureUnit.Fahrenheit, _weather.TemperatureUnit);
            return Math.Round(result, 1);
        }

        public double GetFeelsLike()
        {
            var t = ConvertTemperature(_weather.Temperature, _weather.TemperatureUnit, TemperatureUnit.Fahrenheit);

            if (t <= 40)
                return GetWindChill();

            if (t >= 80)
                return GetHeatIndex();

            return _weather.Temperature;
        }

        //http://planetcalc.com/2089/
        //http://www.webshade.com.au/ShadeInfo/ShadeDesign/apparent.html
        //http://www.bom.gov.au/info/thermal_stress/#apparent
        public double GetApparentWeather()
        {
            var ta = ConvertTemperature(_weather.Temperature, _weather.TemperatureUnit, TemperatureUnit.Celsius);

            // Water vapour pressure (hPa)
            var rh = _weather.Humidity;
            var e = (rh / 100) * 6.105 * Math.Exp(17.27 * ta / (237.7 + ta));
            var ws = WindToMetersPerSecond(_weather.WindSpeed, _speedUnit);
            var at = ta + 0.33 * e - 0.70 * ws - 4.00;

            var result = ConvertTemperature(at, TemperatureUnit.Celsius, _weather.TemperatureUnit);
            return Math.Round(result, 1);
        }

        private double FahrenheitToCelsius(double fahrenheit)
        {
            return Math.Round((fahrenheit - 32) / 1.8000, 2);
        }

        private double CelsiusToFahrenheit(double celsius)
        {
            return Math.Round((celsius * 1.8000) + 32.00, 2);
        }

        private double WindToMilesPerHour(double windSpeed, SpeedUnit unit)
        {
            double result = windSpeed;
            switch (unit)
            {
                case SpeedUnit.Kts:
                    result = 1.1507794 * windSpeed;
                    break;
                case SpeedUnit.Ms:
                    result = 2.23694 * windSpeed;
                    break;
                case SpeedUnit.Fts:
                    result = 0.681818 * windSpeed;
                    break;
                case SpeedUnit.Kmh:
                    result = 0.621371 * windSpeed;
                    break;
                case SpeedUnit.Mph:
                default:
                    result = windSpeed;
                    break;
            }

            return Math.Round(result, 2);
        }

        private double WindToMetersPerSecond(double windSpeed, SpeedUnit unit)
        {
            double result = windSpeed;
            switch (unit)
            {
                case SpeedUnit.Kts:
                    result = 0.5144444 * windSpeed;
                    break;
                case SpeedUnit.Mph:
                    result = 0.44704 * windSpeed;
                    break;
                case SpeedUnit.Fts:
                    result = 0.3048 * windSpeed;
                    break;
                case SpeedUnit.Kmh:
                    result = 0.277778 * windSpeed;
                    break;
                case SpeedUnit.Ms:
                default:
                    result = windSpeed;
                    break;
            }

            return Math.Round(result, 2);
        }

        private double ConvertTemperature(double temp, TemperatureUnit unitIn, TemperatureUnit unitOut)
        {
            if (unitOut == TemperatureUnit.Fahrenheit)
            {
                if (unitIn == TemperatureUnit.Celsius)
                    return CelsiusToFahrenheit(temp);
                return temp;
            }
            else if (unitOut == TemperatureUnit.Celsius)
            {
                if (unitIn == TemperatureUnit.Fahrenheit)
                    return FahrenheitToCelsius(temp);
                return temp;
            }

            return temp;
        }
    }
}
