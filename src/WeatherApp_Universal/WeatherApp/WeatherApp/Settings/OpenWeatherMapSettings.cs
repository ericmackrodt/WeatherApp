using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Provider;

namespace WeatherApp.Settings
{
    public class OpenWeatherMapSettings : IOpenWeatherMapSettings, IWeatherProviderSettings
    {
        public string ApiKey
        {
            get { return "98f97d7a63cbf88e67efb446c61fdd81"; }
        }
    }
}
