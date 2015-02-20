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
            Console.Write("Enter city: ");
            var city = Console.ReadLine();

            Console.Clear();

            if (string.IsNullOrWhiteSpace(city))
                city = "Rio de Janeiro,BR";

            var api = new OpenWeatherMapClient();
            var provider = new WeatherProvider(api);

            Console.WriteLine("Loading...");
            var result = await provider.GetCurrentWeather(-22.91, -43.16, TemperatureUnit.Celsius);

            Console.Clear();
            Console.WriteLine(string.Format("Cidade: {0}", result.CityName));
            var semantic = new SemanticWeather(result, TemperatureUnit.Celsius);
            string semanticWeather = "";
            try
            {
                semanticWeather = semantic.GetSemantic().ToString();
            }
            catch
            {
                semanticWeather = "Wait, What?";
            }

            Console.WriteLine(string.Format("Semantic Weather: {0}", semanticWeather));
            Console.WriteLine(string.Format("Time of the Day: {0}", result.TimeOfDay.ToString()));
            Console.WriteLine(string.Format("Temperature: {0}°C", result.Temperature));
            Console.WriteLine(string.Format("Feels Like: {0}°C", result.FeelsLikeTemperature));
            Console.WriteLine(string.Format("Humidity: {0}%", result.Humidity));
            Console.WriteLine(string.Format("Wind Speed: {0} m/s", result.WindSpeed));
            Console.WriteLine(string.Format("Sunrise: {0:dd/MM/yyyy HH:mm:ss}", result.Sunrise));
            Console.WriteLine(string.Format("Sunset: {0:dd/MM/yyyy HH:mm:ss}", result.Sunset));

            Console.WriteLine(" ");
            MainAsync(args);
        }
    }
}
