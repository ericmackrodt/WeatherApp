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

    public enum WeatherIconType
    {
        Day_ClearSky,
        Day_FewClouds,
        Day_ScatteredClouds,
        Day_BrokenClouds,
        Day_ShowerRain,
        Day_Rain,
        Day_Thunderstorm,
        Day_Snow,
        Day_Mist,
        Night_ClearSky,
        Night_FewClouds,
        Night_ScatteredClouds,
        Night_BrokenClouds,
        Night_ShowerRain,
        Night_Rain,
        Night_Thunderstorm,
        Night_Snow,
        Night_Mist,
        None
    }
}
