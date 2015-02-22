using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider.OpenWeatherMap
{
    //    public class SemanticWeather
    //    {
    //        private CurrentWeatherData _weather;
    //        private TemperatureUnit _temperatureUnit;

    //        public SemanticWeather(CurrentWeatherData weather, TemperatureUnit temperatureUnit)
    //        {
    //            _weather = weather;
    //            _temperatureUnit = temperatureUnit;
    //        }

    //        public SemanticWeatherEnum GetSemantic()
    //        {
    //            switch (_weather.WeatherID)
    //            {
    //                case WeatherConditionCode.Thunderstorm:
    //                case WeatherConditionCode.LightThunderstorm:
    //                case WeatherConditionCode.RaggedThunderstorm:
    //                    return SemanticThunderstorm();
    //                case WeatherConditionCode.HeavyThunderstorm:
    //                    return SemanticHeavyThunderstorm();
    //                case WeatherConditionCode.ThunderstormWithDrizzle:
    //                case WeatherConditionCode.ThunderstormWithHeavyDrizzle:
    //                case WeatherConditionCode.ThunderstormWithHeavyRain:
    //                case WeatherConditionCode.ThunderstormWithLightDrizzle:
    //                case WeatherConditionCode.ThunderstormWithLightRain:
    //                case WeatherConditionCode.ThunderstormWithRain:
    //                    return SemanticThunderstormWithRain();
    //                //Drizzle
    //                case WeatherConditionCode.Drizzle:
    //                case WeatherConditionCode.DrizzleRain:
    //                case WeatherConditionCode.HeavyIntensityDrizzle:
    //                case WeatherConditionCode.HeavyIntensityDrizzleRain:
    //                case WeatherConditionCode.LightIntensityDrizzle:
    //                case WeatherConditionCode.LightIntensityDrizzleRain:
    //                    return SemanticDrizzle();
    //                case WeatherConditionCode.HeavyShowerRainAndDrizzle:
    //                case WeatherConditionCode.ShowerRainAndDrizzle:
    //                case WeatherConditionCode.ShowerDrizzle:
    //                //Rain
    //                case WeatherConditionCode.LightIntensityShowerRain:
    //                case WeatherConditionCode.ShowerRain:
    //                case WeatherConditionCode.HeavyIntensityShowerRain:
    //                case WeatherConditionCode.RaggedShowerRain:
    //                    return SemanticDrizzleAndShower();
    //                //Rain
    //                case WeatherConditionCode.LightRain:
    //                case WeatherConditionCode.ModerateRain:
    //                    return SemanticRain();
    //                case WeatherConditionCode.HeavyIntensityRain:
    //                case WeatherConditionCode.VeryHeavyRain:
    //                case WeatherConditionCode.ExtremeRain:
    //                    return SemanticHeavyRain();
    //                //Rain
    //                case WeatherConditionCode.FreezingRain:
    //                //Snow
    //                case WeatherConditionCode.LightSnow:
    //                case WeatherConditionCode.Snow:
    //                case WeatherConditionCode.HeavySnow:
    //                case WeatherConditionCode.Sleet:
    //                case WeatherConditionCode.ShowerSleet:
    //                case WeatherConditionCode.LightRainAndSnow:
    //                case WeatherConditionCode.RainAndSnow:
    //                case WeatherConditionCode.LightShowerSnow:
    //                case WeatherConditionCode.ShowerSnow:
    //                case WeatherConditionCode.HeavyShowerSnow:
    //                    return SemanticSnow();
    //                case WeatherConditionCode.Mist:
    //                case WeatherConditionCode.Smoke:
    //                case WeatherConditionCode.Haze:
    //                case WeatherConditionCode.SandDustWhirls:
    //                case WeatherConditionCode.Fog:
    //                case WeatherConditionCode.Sand:
    //                case WeatherConditionCode.Dust:
    //                case WeatherConditionCode.VolcanicAsh:
    //                case WeatherConditionCode.Squalls:
    //                case WeatherConditionCode.Tornado:
    //                    return SemanticAtmosphereMist();
    //                //Atmosphere
    //                case WeatherConditionCode.ClearSky:
    //                    return SemanticClearSky();
    //                case WeatherConditionCode.FewClouds:
    //                    return SemanticFewClouds();
    //                case WeatherConditionCode.ScatteredClouds:
    //                    return SemanticScatteredClouds();
    //                case WeatherConditionCode.BrokenClouds:
    //                    return SemanticBrokenClouds();
    //                case WeatherConditionCode.OvercastClouds:
    //                    return SemanticOvercastClouds();
    //                case WeatherConditionCode.Hot:
    //                    return SemanticExtremelyHot();
    //                case WeatherConditionCode.Cold:
    //                    return SemanticExtremelyCold();
    //                case WeatherConditionCode.Tornado_Extreme:
    //                case WeatherConditionCode.TropicalStorm:
    //                case WeatherConditionCode.Hurricane:
    //                case WeatherConditionCode.Windy:
    //                case WeatherConditionCode.hail:
    //                    return SemanticWeatherEnum.Extreme;
    //                case WeatherConditionCode.Calm:
    //                case WeatherConditionCode.LightBreeze:
    //                case WeatherConditionCode.GentleBreeze:
    //                case WeatherConditionCode.FreshBreeze:
    //                case WeatherConditionCode.StrongBreeze:
    //                    return SemanticBreeze();
    //                case WeatherConditionCode.HighWindNearGale:
    //                case WeatherConditionCode.Gale:
    //                case WeatherConditionCode.SevereGale:
    //                    return SemanticHeavyWind();
    //                case WeatherConditionCode.Storm:
    //                case WeatherConditionCode.ViolentStorm:
    //                case WeatherConditionCode.Hurricane_Additional:
    //                    return SemanticWeatherEnum.Extreme;
    //                default:
    //                    return SemanticWeatherEnum.Unknown;
    //            }
    //        }

    //        private SemanticWeatherEnum SemanticHeavyWind()
    //        {
    //            return SemanticWeatherEnum.HeavyWind;
    //        }

    //        private SemanticWeatherEnum SemanticBreeze()
    //        {
    //            return TemperatureToSemantic();
    //        }

    //        private SemanticWeatherEnum SemanticThunderstormWithRain()
    //        {
    //            return SemanticWeatherEnum.ThunderstormRain;
    //        }

    //        private SemanticWeatherEnum SemanticHeavyThunderstorm()
    //        {
    //            return SemanticWeatherEnum.HeavyThunderstorm;
    //        }

    //        private SemanticWeatherEnum SemanticDrizzle()
    //        {
    //            return SemanticWeatherEnum.Rain;
    //        }

    //        private SemanticWeatherEnum SemanticHeavyRain()
    //        {
    //            return SemanticWeatherEnum.HeavyRain;
    //        }

    //        private SemanticWeatherEnum SemanticOvercastClouds()
    //        {
    //            return SemanticWeatherEnum.HeavyClouds;
    //        }

    //        private SemanticWeatherEnum SemanticExtremelyCold()
    //        {
    //            return SemanticWeatherEnum.VeryCold;
    //        }

    //        private SemanticWeatherEnum SemanticExtremelyHot()
    //        {
    //            return SemanticWeatherEnum.VeryHot;
    //        }

    //        private SemanticWeatherEnum SemanticBrokenClouds()
    //        {
    //            return TemperatureToSemantic();
    //        }

    //        private SemanticWeatherEnum SemanticScatteredClouds()
    //        {
    //            return TemperatureToSemantic();
    //        }

    //        private SemanticWeatherEnum SemanticFewClouds()
    //        {
    //            return TemperatureToSemantic();
    //        }

    //        private SemanticWeatherEnum SemanticClearSky()
    //        {
    //            return TemperatureToSemantic();
    //        }

    //        private SemanticWeatherEnum SemanticAtmosphereMist()
    //        {
    //            return SemanticWeatherEnum.Mist;
    //        }

    //        private SemanticWeatherEnum SemanticSnow()
    //        {
    //            return SemanticWeatherEnum.Snow;
    //        }

    //        private SemanticWeatherEnum SemanticRain()
    //        {
    //            if (_weather.FeelsLikeTemperature < 15)
    //                return SemanticWeatherEnum.Rain_Cold;
    //            if (_weather.FeelsLikeTemperature > 30)
    //                return SemanticWeatherEnum.Rain_Hot;

    //            return SemanticWeatherEnum.Rain;
    //        }

    //        private SemanticWeatherEnum SemanticDrizzleAndShower()
    //        {
    //            return SemanticWeatherEnum.Rain;
    //        }

    //        private SemanticWeatherEnum SemanticThunderstorm()
    //        {
    //            return SemanticWeatherEnum.Thunderstorm;
    //        }

    //        private SemanticWeatherEnum TemperatureToSemantic()
    //        {
    //            if (_weather.FeelsLikeTemperature < 5)
    //                return SemanticWeatherEnum.VeryCold;
    //            if (_weather.FeelsLikeTemperature < 15)
    //                return SemanticWeatherEnum.Cold;
    //            if (_weather.FeelsLikeTemperature > 45)
    //                return SemanticWeatherEnum.VeryHot;
    //            if (_weather.FeelsLikeTemperature > 30)
    //                return SemanticWeatherEnum.Hot;
    //            if (_weather.FeelsLikeTemperature > 20)
    //                return SemanticWeatherEnum.Nice;

    //            return SemanticWeatherEnum.NotBad;
    //        }
    //    }
    //}

}
