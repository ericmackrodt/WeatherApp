using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider.OpenWeatherMap
{
    public class SemanticOpenWeatherMap
    {
        private WeatherData _weather;

        public SemanticOpenWeatherMap(WeatherData weather)
        {
            _weather = weather;
        }

        public SemanticWeatherEnum GetSemantic()
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
                    return SemanticWeatherEnum.Thunderstorm;
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
                    return SemanticWeatherEnum.Raining;
                //Snow
                case WeatherConditionCode.LightSnow:
                case WeatherConditionCode.Snow:
                case WeatherConditionCode.HeavySnow:
                case WeatherConditionCode.Sleet:
                case WeatherConditionCode.ShowerSleet:
                case WeatherConditionCode.LightRainAndSnow:
                case WeatherConditionCode.RainAndSnow:
                case WeatherConditionCode.LightShowerSnow:
                case WeatherConditionCode.ShowerSnow:
                case WeatherConditionCode.HeavyShowerSnow:
                    return SemanticWeatherEnum.Snow;
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
                    return SemanticWeatherEnum.Fog;
                //Atmosphere
                case WeatherConditionCode.ClearSky:
                    return SemanticWeatherEnum.Clear;
                case WeatherConditionCode.FewClouds:
                case WeatherConditionCode.ScatteredClouds:
                case WeatherConditionCode.BrokenClouds:
                    return SemanticWeatherEnum.PartlyCloudy;
                case WeatherConditionCode.OvercastClouds:
                    return SemanticWeatherEnum.Overcast;
                case WeatherConditionCode.Hot:
                case WeatherConditionCode.Cold:
                case WeatherConditionCode.Tornado_Extreme:
                case WeatherConditionCode.TropicalStorm:
                case WeatherConditionCode.Hurricane:
                case WeatherConditionCode.Windy:
                case WeatherConditionCode.hail:
                    return SemanticWeatherEnum.Extreme;
                case WeatherConditionCode.Calm:
                case WeatherConditionCode.LightBreeze:
                case WeatherConditionCode.GentleBreeze:
                case WeatherConditionCode.FreshBreeze:
                case WeatherConditionCode.StrongBreeze:
                case WeatherConditionCode.HighWindNearGale:
                case WeatherConditionCode.Gale:
                case WeatherConditionCode.SevereGale:
                    return SemanticWeatherEnum.Wind;
                case WeatherConditionCode.Storm:
                case WeatherConditionCode.ViolentStorm:
                case WeatherConditionCode.Hurricane_Additional:
                    return SemanticWeatherEnum.Extreme;
                default:
                    return SemanticWeatherEnum.Other;
            }
        }
    }
}

