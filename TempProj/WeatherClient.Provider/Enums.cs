using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Provider
{
    public enum SpeedUnit
    {
        Kts, //Knots
        Ms, //Metre per second
        Fts, //Feet per second
        Kmh, //Kilometers per hour
        Mph, //Miles per hour
    }

    public enum TemperatureUnit
    {
        Celsius = 0,
        Fahrenheit = 1
    }

    public enum TimeOfDay
    {
        Day,
        Night
    }

    public enum WeatherIconType
    {
        ClearSky,
        FewClouds,
        ScatteredClouds,
        BrokenClouds,
        ShowerRain,
        Rain,
        Thunderstorm,
        Snow,
        Mist,
        None
    }
}
