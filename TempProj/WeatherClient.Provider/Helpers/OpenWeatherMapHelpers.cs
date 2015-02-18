using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherClient.Provider.Helpers
{
    public static class OpenWeatherMapHelpers
    {
        public static WeatherIconType ToWeatherIconType(this WeatherConditionData data)
        {
            try
            {
                var match = Regex.Match(data.Icon, @"^(?<code>\d{2})(?<day>\w)$");
                var code = int.Parse(match.Groups["code"].Value);
                var day = match.Groups["day"].Value.ToLower() == "d";
                switch (code)
                {
                    case 1:
                        return WeatherIconType.ClearSky;
                    case 2:
                        return WeatherIconType.FewClouds;
                    case 3:
                        return WeatherIconType.ScatteredClouds;
                    case 4:
                        return WeatherIconType.BrokenClouds;
                    case 9:
                        return WeatherIconType.ShowerRain;
                    case 10:
                        return WeatherIconType.Rain;
                    case 11:
                        return WeatherIconType.Thunderstorm;
                    case 13:
                        return WeatherIconType.Snow;
                    case 50:
                        return WeatherIconType.Mist;
                    default:
                        return WeatherIconType.None;
                }
            }
            catch
            {
                return WeatherIconType.None;
            }
        }
    }
}
