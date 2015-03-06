using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
    public enum WeatherConditionType
    {
        Clear,
        Rain,
        PartlyCloudy,
        Overcast,
        Thunderstorm,
        Snow,
        Sleet,
        Wind,
        Fog,
        Drizzle,
        Hail,
        Extreme,//
        Other//
    }

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
}
