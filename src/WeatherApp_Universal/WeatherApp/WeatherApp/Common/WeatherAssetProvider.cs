using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Provider;

namespace WeatherApp.Common
{
    public class WeatherAssetProvider : IWeatherAssetProvider
    {
        private WeatherDictionary<char> icons;
        public WeatherDictionary<char> Icons
        {
            get { return icons; }
        }

        private WeatherDictionary<string> backgrounds;
        public WeatherDictionary<string> Backgrounds
        {
            get { return backgrounds; }
        }
        
        public WeatherAssetProvider()
        {
            SetBackgrounds();
            SetIcons();
        }

        private void SetIcons()
        {
            icons = new WeatherDictionary<char>();
            icons.Add(WeatherConditionType.Clear,           TimeOfDay.Day, (char)Int16.Parse("f00d", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Drizzle,         TimeOfDay.Day, (char)Int16.Parse("f04e", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Extreme,         TimeOfDay.Day, (char)Int16.Parse("f0c7", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Fog,             TimeOfDay.Day, (char)Int16.Parse("f003", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Hail,            TimeOfDay.Day, (char)Int16.Parse("f004", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.HeavyRain,       TimeOfDay.Day, (char)Int16.Parse("f008", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.HeavySnow,       TimeOfDay.Day, (char)Int16.Parse("f00a", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Other,           TimeOfDay.Day, (char)Int16.Parse("f00d", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Overcast,        TimeOfDay.Day, (char)Int16.Parse("f00c", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.PartlyCloudy,    TimeOfDay.Day, (char)Int16.Parse("f002", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Rain,            TimeOfDay.Day, (char)Int16.Parse("f008", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Sleet,           TimeOfDay.Day, (char)Int16.Parse("f0b2", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Snow,            TimeOfDay.Day, (char)Int16.Parse("f00a", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Thunderstorm,    TimeOfDay.Day, (char)Int16.Parse("f010", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Wind,            TimeOfDay.Day, (char)Int16.Parse("f007", NumberStyles.AllowHexSpecifier));
            
            icons.Add(WeatherConditionType.Clear,           TimeOfDay.Night, (char)Int16.Parse("f02e", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Drizzle,         TimeOfDay.Night, (char)Int16.Parse("f02b", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Extreme,         TimeOfDay.Night, (char)Int16.Parse("f0c7", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Fog,             TimeOfDay.Night, (char)Int16.Parse("f04a", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Hail,            TimeOfDay.Night, (char)Int16.Parse("f032", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.HeavyRain,       TimeOfDay.Night, (char)Int16.Parse("f029", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.HeavySnow,       TimeOfDay.Night, (char)Int16.Parse("f02a", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Other,           TimeOfDay.Night, (char)Int16.Parse("f00d", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Overcast,        TimeOfDay.Night, (char)Int16.Parse("f00c", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.PartlyCloudy,    TimeOfDay.Night, (char)Int16.Parse("f083", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Rain,            TimeOfDay.Night, (char)Int16.Parse("f028", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Sleet,           TimeOfDay.Night, (char)Int16.Parse("f0b4", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Snow,            TimeOfDay.Night, (char)Int16.Parse("f02a", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Thunderstorm,    TimeOfDay.Night, (char)Int16.Parse("f02d", NumberStyles.AllowHexSpecifier));
            icons.Add(WeatherConditionType.Wind,            TimeOfDay.Night, (char)Int16.Parse("f023", NumberStyles.AllowHexSpecifier));
        }

        private void SetBackgrounds()
        {
            backgrounds = new WeatherDictionary<string>();
            backgrounds.Add(WeatherConditionType.Clear,             TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/01d.jpg");
            backgrounds.Add(WeatherConditionType.Drizzle,           TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/09d.jpg");
            backgrounds.Add(WeatherConditionType.Extreme,           TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/11d.jpg");
            backgrounds.Add(WeatherConditionType.Fog,               TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/50d.jpg");
            backgrounds.Add(WeatherConditionType.Hail,              TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/10d.jpg");
            backgrounds.Add(WeatherConditionType.HeavyRain,         TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/10d.jpg");
            backgrounds.Add(WeatherConditionType.HeavySnow,         TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/13d.jpg");
            backgrounds.Add(WeatherConditionType.Other,             TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/01d.jpg");
            backgrounds.Add(WeatherConditionType.Overcast,          TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/04d.jpg");
            backgrounds.Add(WeatherConditionType.PartlyCloudy,      TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/03d.jpg");
            backgrounds.Add(WeatherConditionType.Rain,              TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/10d.jpg");
            backgrounds.Add(WeatherConditionType.Sleet,             TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/10d.jpg");
            backgrounds.Add(WeatherConditionType.Snow,              TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/13d.jpg");
            backgrounds.Add(WeatherConditionType.Thunderstorm,      TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/11d.jpg");
            backgrounds.Add(WeatherConditionType.Wind,              TimeOfDay.Day, "ms-appx:///Assets/WeatherBackgrounds/02d.jpg");
            backgrounds.Add(WeatherConditionType.Clear,             TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/01n.jpg");
            backgrounds.Add(WeatherConditionType.Drizzle,           TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/09n.jpg");
            backgrounds.Add(WeatherConditionType.Extreme,           TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/11n.jpg");
            backgrounds.Add(WeatherConditionType.Fog,               TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/50n.jpg");
            backgrounds.Add(WeatherConditionType.Hail,              TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/10n.jpg");
            backgrounds.Add(WeatherConditionType.HeavyRain,         TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/10n.jpg");
            backgrounds.Add(WeatherConditionType.HeavySnow,         TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/13n.jpg");
            backgrounds.Add(WeatherConditionType.Other,             TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/01n.jpg");
            backgrounds.Add(WeatherConditionType.Overcast,          TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/04n.jpg");
            backgrounds.Add(WeatherConditionType.PartlyCloudy,      TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/03n.jpg");
            backgrounds.Add(WeatherConditionType.Rain,              TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/10n.jpg");
            backgrounds.Add(WeatherConditionType.Sleet,             TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/10n.jpg");
            backgrounds.Add(WeatherConditionType.Snow,              TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/13n.jpg");
            backgrounds.Add(WeatherConditionType.Thunderstorm,      TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/11n.jpg");
            backgrounds.Add(WeatherConditionType.Wind,              TimeOfDay.Night, "ms-appx:///Assets/WeatherBackgrounds/02n.jpg");
        }
    }
}
