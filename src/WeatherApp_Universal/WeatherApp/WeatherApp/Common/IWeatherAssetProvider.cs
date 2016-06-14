using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Common
{
    public interface IWeatherAssetProvider
    {
        WeatherDictionary<string> Backgrounds { get; }
        WeatherDictionary<char> Icons { get; }
    }
}
