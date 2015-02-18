using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Provider
{
    public class SemanticWeather
    {
        private WeatherData _weather;
        private TemperatureUnit _temperatureUnit;

        public SemanticWeather(WeatherData weather, TemperatureUnit temperatureUnit)
        {
            _weather = weather;
            _temperatureUnit = temperatureUnit;
        }

        public SemanticWeatherEnum GetSemantic()
        {
            switch (_weather.WeatherID)
            {
                case WeatherConditionCode.Thunderstorm:
                case WeatherConditionCode.ThunderstormWithDrizzle:
                case WeatherConditionCode.ThunderstormWithHeavyDrizzle:
                case WeatherConditionCode.ThunderstormWithHeavyRain:
                case WeatherConditionCode.ThunderstormWithLightDrizzle:
                case WeatherConditionCode.ThunderstormWithLightRain:
                case WeatherConditionCode.ThunderstormWithRain:
                case WeatherConditionCode.LightThunderstorm:
                case WeatherConditionCode.HeavyThunderstorm:
                case WeatherConditionCode.RaggedThunderstorm:
                    return SemanticThunderstorm();
                //Drizzle
                case WeatherConditionCode.Drizzle:
                case WeatherConditionCode.DrizzleRain:
                case WeatherConditionCode.HeavyIntensityDrizzle:
                case WeatherConditionCode.HeavyIntensityDrizzleRain:
                case WeatherConditionCode.HeavyShowerRainAndDrizzle:
                case WeatherConditionCode.LightIntensityDrizzle:
                case WeatherConditionCode.LightIntensityDrizzleRain:
                case WeatherConditionCode.ShowerRainAndDrizzle:
                case WeatherConditionCode.ShowerDrizzle:
                //Rain
                case WeatherConditionCode.LightIntensityShowerRain:
                case WeatherConditionCode.ShowerRain:
                case WeatherConditionCode.HeavyIntensityShowerRain:
                case WeatherConditionCode.RaggedShowerRain:
                    return SemanticDrizzleAndShower();
                //Rain
                case WeatherConditionCode.LightRain:
                case WeatherConditionCode.ModerateRain:
                case WeatherConditionCode.HeavyIntensityRain:
                case WeatherConditionCode.VeryHeavyRain:
                case WeatherConditionCode.ExtremeRain:
                    return SemanticRain();
                //Rain
                case WeatherConditionCode.FreezingRain:
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
                    return SemanticSnow();
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
                    return SemanticAtmosphereMist();
                case WeatherConditionCode.ClearSky:
                    return SemanticClearSky();
                case WeatherConditionCode.FewClouds:
                    return SemanticFewClouds();
                case WeatherConditionCode.ScatteredClouds:
                    return SemanticScatteredClouds();
                case WeatherConditionCode.BrokenClouds:
                    return SemanticBrokenClouds();
                case WeatherConditionCode.Hot:
                    return SemanticExtremelyHot();
                case WeatherConditionCode.Cold:
                    return SemanticExtremelyCold();
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
                case WeatherConditionCode.Storm:
                case WeatherConditionCode.ViolentStorm:
                case WeatherConditionCode.Hurricane_Additional:
                default:
                    return SemanticWeatherEnum.Unknown;
            }
        }

        private SemanticWeatherEnum SemanticExtremelyCold()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticExtremelyHot()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticBrokenClouds()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticScatteredClouds()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticFewClouds()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticClearSky()
        {
            if (_weather.FeelsLikeTemperature < 5)
                return SemanticWeatherEnum.Clear_VeryCold;
            if (_weather.FeelsLikeTemperature < 15)
                return SemanticWeatherEnum.Clear_Cold;
            if (_weather.FeelsLikeTemperature > 45)
                return SemanticWeatherEnum.Clear_VeryHot;
            if (_weather.FeelsLikeTemperature > 30)
                return SemanticWeatherEnum.Clear_Hot;
            if (_weather.FeelsLikeTemperature > 20)
                return SemanticWeatherEnum.Clear_Nice;
            
            return SemanticWeatherEnum.Clear_NotBad;
        }

        private SemanticWeatherEnum SemanticAtmosphereMist()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticSnow()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticRain()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticDrizzleAndShower()
        {
            throw new NotImplementedException();
        }

        private SemanticWeatherEnum SemanticThunderstorm()
        {
            throw new NotImplementedException();
        }
    }
}
