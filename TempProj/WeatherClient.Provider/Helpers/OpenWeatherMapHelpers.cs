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
                        return day ? WeatherIconType.Day_ClearSky : WeatherIconType.Night_ClearSky;
                    case 2:
                        return day ? WeatherIconType.Day_FewClouds : WeatherIconType.Night_FewClouds;
                    case 3:
                        return day ? WeatherIconType.Day_ScatteredClouds : WeatherIconType.Night_ScatteredClouds;
                    case 4:
                        return day ? WeatherIconType.Day_BrokenClouds : WeatherIconType.Day_BrokenClouds;
                    case 9:
                        return day ? WeatherIconType.Day_ShowerRain : WeatherIconType.Night_ShowerRain;
                    case 10:
                        return day ? WeatherIconType.Day_Rain : WeatherIconType.Night_Rain;
                    case 11:
                        return day ? WeatherIconType.Day_Thunderstorm : WeatherIconType.Night_Thunderstorm;
                    case 13:
                        return day ? WeatherIconType.Day_Snow : WeatherIconType.Night_Snow;
                    case 50:
                        return day ? WeatherIconType.Day_Mist : WeatherIconType.Night_Mist;
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
