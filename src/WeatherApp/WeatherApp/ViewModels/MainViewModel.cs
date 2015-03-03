using MVVMBasic;
using MVVMBasic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Common;
using WeatherApp.Provider;

namespace WeatherApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IWeatherProvider _weatherProvider;
        private ILocationProvider _locationProvider;
        private ISentenceProvider _sentenceProvider;

        private BaseWeatherData _weatherData;
        public BaseWeatherData WeatherData
        {
            get { return _weatherData; }
            set
            {
                _weatherData = value;
                NotifyChanged();
            }
        }

        private SentenceData _semanticWeather;
        public SentenceData SemanticWeather
        {
            get { return _semanticWeather; }
            set
            {
                _semanticWeather = value;
                NotifyChanged();
            }
        }

        private ICommand _refreshWeatherCommand;
        public ICommand RefreshWeatherCommand
        {
            get { return _refreshWeatherCommand; }
        }

        public MainViewModel(IWeatherProvider weatherProvider, ISentenceProvider sentenceProvider, ILocationProvider locationProvider)
        {
            _weatherProvider = weatherProvider;
            _locationProvider = locationProvider;
            _sentenceProvider = sentenceProvider;

            _refreshWeatherCommand = new AsyncRelayCommand(RefreshWeather);
        }

        public override async Task LoadData(object arg)
        {
            await RefreshWeather(arg);
        }

        private async Task RefreshWeather(object arg)
        {
            var location = await _locationProvider.GetLocation();
            var data = await _weatherProvider.GetCurrentWeather(location.Point.Position.Latitude, location.Point.Position.Longitude, TemperatureUnit.Celsius);

            await SetWeather(data);
        }

        private async Task SetWeather(BaseWeatherData data)
        {
            var sentence = await _sentenceProvider.GetSentence(data);
            SemanticWeather = sentence;
            WeatherData = data;
        }

        int currentWeather = 0;
        internal async void CycleWeather()
        {
            var weatherList = new List<BaseWeatherData>();
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ClearSky, WeatherIconType.ClearSky, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.BrokenClouds, WeatherIconType.BrokenClouds, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.FewClouds, WeatherIconType.FewClouds, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Mist, WeatherIconType.Mist, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ShowerRain, WeatherIconType.Rain, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ScatteredClouds, WeatherIconType.ScatteredClouds, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ShowerRain, WeatherIconType.ShowerRain, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Snow, WeatherIconType.Snow, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Thunderstorm, WeatherIconType.Thunderstorm, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.OvercastClouds, WeatherIconType.ScatteredClouds, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Sleet, WeatherIconType.Snow, TimeOfDay.Day));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ClearSky, WeatherIconType.ClearSky, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.BrokenClouds, WeatherIconType.BrokenClouds, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.FewClouds, WeatherIconType.FewClouds, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Mist, WeatherIconType.Mist, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ShowerRain, WeatherIconType.Rain, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ScatteredClouds, WeatherIconType.ScatteredClouds, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.ShowerRain, WeatherIconType.ShowerRain, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Snow, WeatherIconType.Snow, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Thunderstorm, WeatherIconType.Thunderstorm, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.OvercastClouds, WeatherIconType.ScatteredClouds, TimeOfDay.Night));
            weatherList.Add(NewMethod(OpenWeatherMapApiClient.WeatherConditionCode.Sleet, WeatherIconType.Snow, TimeOfDay.Night));

            await SetWeather(weatherList[currentWeather]);

            if (currentWeather == 21)
                currentWeather = 0;
            else
                currentWeather++;
        }

        private static Provider.OpenWeatherMap.WeatherData NewMethod(OpenWeatherMapApiClient.WeatherConditionCode weatherId, WeatherIconType iconType, TimeOfDay timeOfDay)
        {
            var weatherData = new WeatherApp.Provider.OpenWeatherMap.WeatherData()
            {
                CityName = "Whatever",
                Date = DateTime.Now,
                Humidity = 60,
                IconType = iconType,
                Temperature = 25,
                WindSpeed = 5,
                WeatherID = weatherId
            };

            var semantic = new WeatherApp.Provider.OpenWeatherMap.SemanticOpenWeatherMap(weatherData);
            weatherData.SemanticWeather = semantic.GetSemantic();

            if (timeOfDay == TimeOfDay.Day)
            {
                weatherData.Sunrise = DateTime.Now.AddHours(-6);
                weatherData.Sunset = DateTime.Now.AddHours(6);
            }
            else
            {
                weatherData.Sunrise = DateTime.Now.AddHours(-12);
                weatherData.Sunset = DateTime.Now.AddHours(-6);
            }
            
            return weatherData;
        }
    }
}
