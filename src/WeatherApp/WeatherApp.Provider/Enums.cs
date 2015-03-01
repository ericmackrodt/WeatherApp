using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
//    no condition
//clear
//raining|rain
//cloudy
//partly cloudy
//snow
//sleet
//wind
//fog

    public enum SemanticWeatherEnum
    {
        Clear,
        Raining,
        PartlyCloudy,
        Overcast,
        Thunderstorm,
        Snow,
        Sleet,
        Wind,
        Fog,
        Extreme,
        Other


        //Unknown,
        //Extreme,
        //Nice,
        //NotBad,
        //Cold,
        //VeryCold,
        //Hot,
        //VeryHot,
        //HeavyClouds,
        //Rain,
        //Rain_Cold,
        //Rain_Hot,
        //HeavyRain,
        //Snow,
        //Thunderstorm,
        //ThunderstormRain,
        //HeavyThunderstorm,
        //Mist,
        //HeavyWind
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
