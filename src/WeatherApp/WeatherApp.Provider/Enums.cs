using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
    public enum SemanticWeatherEnum
    {
        Unknown,
        Extreme,
        Nice,
        NotBad,
        Cold,
        VeryCold,
        Hot,
        VeryHot,
        HeavyClouds,
        Rain,
        Rain_Cold,
        Rain_Hot,
        HeavyRain,
        Snow,
        Thunderstorm,
        ThunderstormRain,
        HeavyThunderstorm,
        Mist,
        HeavyWind
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
