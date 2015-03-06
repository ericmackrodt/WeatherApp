using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider.OpenWeatherMap
{
    public class OWMWeatherTypeConverter
    {
        private WeatherData _weather;

        public OWMWeatherTypeConverter(WeatherData weather)
        {
            _weather = weather;
        }

        public WeatherConditionType GetSemantic()
        {
            switch (_weather.WeatherID)
            {
                case WeatherConditionCode.Thunderstorm:
                case WeatherConditionCode.LightThunderstorm:
                case WeatherConditionCode.RaggedThunderstorm:
                case WeatherConditionCode.HeavyThunderstorm:
                case WeatherConditionCode.ThunderstormWithDrizzle:
                case WeatherConditionCode.ThunderstormWithHeavyDrizzle:
                case WeatherConditionCode.ThunderstormWithHeavyRain:
                case WeatherConditionCode.ThunderstormWithLightDrizzle:
                case WeatherConditionCode.ThunderstormWithLightRain:
                case WeatherConditionCode.ThunderstormWithRain:
                    return WeatherConditionType.Thunderstorm;
                //Drizzle
                case WeatherConditionCode.Drizzle:
                case WeatherConditionCode.DrizzleRain:
                case WeatherConditionCode.HeavyIntensityDrizzle:
                case WeatherConditionCode.HeavyIntensityDrizzleRain:
                case WeatherConditionCode.LightIntensityDrizzle:
                case WeatherConditionCode.LightIntensityDrizzleRain:
                case WeatherConditionCode.HeavyShowerRainAndDrizzle:
                case WeatherConditionCode.ShowerRainAndDrizzle:
                case WeatherConditionCode.ShowerDrizzle:
                    return WeatherConditionType.Drizzle;
                //Rain
                case WeatherConditionCode.LightIntensityShowerRain:
                case WeatherConditionCode.ShowerRain:
                case WeatherConditionCode.HeavyIntensityShowerRain:
                case WeatherConditionCode.RaggedShowerRain:
                //Rain
                case WeatherConditionCode.LightRain:
                case WeatherConditionCode.ModerateRain:
                case WeatherConditionCode.HeavyIntensityRain:
                case WeatherConditionCode.VeryHeavyRain:
                case WeatherConditionCode.ExtremeRain:
                //Rain
                case WeatherConditionCode.FreezingRain:
                    return WeatherConditionType.Rain;
                //Snow
                case WeatherConditionCode.LightSnow:
                case WeatherConditionCode.Snow:
                case WeatherConditionCode.HeavySnow:
                case WeatherConditionCode.LightShowerSnow:
                case WeatherConditionCode.ShowerSnow:
                case WeatherConditionCode.HeavyShowerSnow:
                    return WeatherConditionType.Snow;
                case WeatherConditionCode.LightRainAndSnow:
                case WeatherConditionCode.RainAndSnow:
                case WeatherConditionCode.Sleet:
                case WeatherConditionCode.ShowerSleet:
                    return WeatherConditionType.Sleet;
                case WeatherConditionCode.Mist:
                case WeatherConditionCode.Smoke:
                case WeatherConditionCode.Haze:
                case WeatherConditionCode.SandDustWhirls:
                case WeatherConditionCode.Fog:
                case WeatherConditionCode.Sand:
                case WeatherConditionCode.Dust:
                case WeatherConditionCode.VolcanicAsh:
                case WeatherConditionCode.Squalls:
                case WeatherConditionCode.Tornado:
                    return WeatherConditionType.Fog;
                //Atmosphere
                case WeatherConditionCode.ClearSky:
                    return WeatherConditionType.Clear;
                case WeatherConditionCode.FewClouds:
                case WeatherConditionCode.ScatteredClouds:
                case WeatherConditionCode.BrokenClouds:
                    return WeatherConditionType.PartlyCloudy;
                case WeatherConditionCode.OvercastClouds:
                    return WeatherConditionType.Overcast;
                case WeatherConditionCode.Hot:
                case WeatherConditionCode.Cold:
                case WeatherConditionCode.Tornado_Extreme:
                case WeatherConditionCode.TropicalStorm:
                case WeatherConditionCode.Hurricane:
                case WeatherConditionCode.Windy:
                    return WeatherConditionType.Extreme;
                case WeatherConditionCode.Hail:
                    return WeatherConditionType.Hail;
                //Wind
                case WeatherConditionCode.Calm:
                case WeatherConditionCode.LightBreeze:
                case WeatherConditionCode.GentleBreeze:
                case WeatherConditionCode.FreshBreeze:
                case WeatherConditionCode.StrongBreeze:
                    return WeatherConditionType.Clear;
                case WeatherConditionCode.HighWindNearGale:
                case WeatherConditionCode.Gale:
                case WeatherConditionCode.SevereGale:
                    return WeatherConditionType.Wind;
                case WeatherConditionCode.Storm:
                case WeatherConditionCode.ViolentStorm:
                case WeatherConditionCode.Hurricane_Additional:
                    return WeatherConditionType.Extreme;
                default:
                    return WeatherConditionType.Other;
            }
        }
    }
}

