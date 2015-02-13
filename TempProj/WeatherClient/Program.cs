using Nito.AsyncEx;
using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClient.Provider;

namespace WeatherClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        private static async void MainAsync(string[] args)
        {
            var api = new OpenWeatherMapClient();
            var provider = new WeatherProvider(api);
            var result = await provider.GetCurrentWeather("Rio de Janeiro,Br", TemperatureUnit.Celsius);

            Console.WriteLine(string.Format("Cidade: {0}", result.CityName));
            Console.WriteLine(string.Format("Degrees: {0}", result.Temperature));
            Console.WriteLine(string.Format("Sunrise: {0:dd/MM/yyyy HH:mm}", result.Sunrise));
            Console.WriteLine(string.Format("Sunset: {0:dd/MM/yyyy HH:mm}", result.Sunset));

            Console.ReadKey();
        }
    }
}
