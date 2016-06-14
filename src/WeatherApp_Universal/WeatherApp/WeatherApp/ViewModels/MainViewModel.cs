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
        public event EventHandler WeatherLoaded;

        private IWeatherProvider _weatherProvider;
        private ILocationProvider _locationProvider;
        private ISentenceProvider _sentenceProvider;
        private IWeatherAssetProvider weatherAssetProvider;

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

        private string background;
        public string Background
        {
            get { return background; }
            set
            {
                background = value;
                NotifyChanged();
            }
        }

        private char icon;
        public char Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                NotifyChanged();
            }
        }
        
        private ICommand _refreshWeatherCommand;
        public ICommand RefreshWeatherCommand
        {
            get { return _refreshWeatherCommand; }
        }
        
        public MainViewModel(IWeatherProvider weatherProvider, ISentenceProvider sentenceProvider, ILocationProvider locationProvider, IWeatherAssetProvider assetProvider)
        {
            _weatherProvider = weatherProvider;
            _locationProvider = locationProvider;
            _sentenceProvider = sentenceProvider;
            this.weatherAssetProvider = assetProvider;

            _refreshWeatherCommand = new RelayCommandAsync(RefreshWeather);
        }

        public override async Task LoadData(object arg)
        {
            await RefreshWeather(arg);
        }

        internal async void Upd()
        {
            await SetWeather(_weatherData);
        }

        private async Task RefreshWeather(object arg)
        {
            var location = await _locationProvider.GetLocation();
            var data = await _weatherProvider.GetCurrentWeather(location.Point.Position.Latitude, location.Point.Position.Longitude, TemperatureUnit.Celsius);

            await SetWeather(data);

            if (WeatherLoaded != null)
                WeatherLoaded(this, new EventArgs());
        }

        private async Task SetWeather(BaseWeatherData data)
        {
            var sentence = await _sentenceProvider.GetSentence(data);
            SemanticWeather = sentence;
            WeatherData = data;
            Icon = weatherAssetProvider.Icons[data.ConditionType, data.TimeOfDay];
            Background = weatherAssetProvider.Backgrounds[data.ConditionType, data.TimeOfDay];
        }

        int currentWeather = 0;
        internal async void CycleWeather()
        {
            var weatherList = new List<BaseWeatherData>();
            weatherList.Add(NewMethod("11d",OpenWeatherMapApiClient.WeatherConditionCode.Thunderstorm, TimeOfDay.Day));
            weatherList.Add(NewMethod("10d",OpenWeatherMapApiClient.WeatherConditionCode.Drizzle, TimeOfDay.Day));
            weatherList.Add(NewMethod("09d",OpenWeatherMapApiClient.WeatherConditionCode.ShowerRain, TimeOfDay.Day));
            weatherList.Add(NewMethod("13d",OpenWeatherMapApiClient.WeatherConditionCode.Snow, TimeOfDay.Day));
            weatherList.Add(NewMethod("13d",OpenWeatherMapApiClient.WeatherConditionCode.Sleet, TimeOfDay.Day));
            weatherList.Add(NewMethod("50d",OpenWeatherMapApiClient.WeatherConditionCode.Fog, TimeOfDay.Day));
            weatherList.Add(NewMethod("01d",OpenWeatherMapApiClient.WeatherConditionCode.ClearSky, TimeOfDay.Day));
            weatherList.Add(NewMethod("03d",OpenWeatherMapApiClient.WeatherConditionCode.ScatteredClouds, TimeOfDay.Day));
            weatherList.Add(NewMethod("04d",OpenWeatherMapApiClient.WeatherConditionCode.OvercastClouds, TimeOfDay.Day));
            weatherList.Add(NewMethod("13d",OpenWeatherMapApiClient.WeatherConditionCode.Hail, TimeOfDay.Day));
            weatherList.Add(NewMethod("13d",OpenWeatherMapApiClient.WeatherConditionCode.Gale, TimeOfDay.Day));
                                      
            weatherList.Add(NewMethod("11n",OpenWeatherMapApiClient.WeatherConditionCode.Thunderstorm, TimeOfDay.Night));
            weatherList.Add(NewMethod("10n",OpenWeatherMapApiClient.WeatherConditionCode.Drizzle, TimeOfDay.Night));
            weatherList.Add(NewMethod("09n",OpenWeatherMapApiClient.WeatherConditionCode.ShowerRain, TimeOfDay.Night));
            weatherList.Add(NewMethod("13n",OpenWeatherMapApiClient.WeatherConditionCode.Snow, TimeOfDay.Night));
            weatherList.Add(NewMethod("13n",OpenWeatherMapApiClient.WeatherConditionCode.Sleet, TimeOfDay.Night));
            weatherList.Add(NewMethod("50n",OpenWeatherMapApiClient.WeatherConditionCode.Fog, TimeOfDay.Night));
            weatherList.Add(NewMethod("01n",OpenWeatherMapApiClient.WeatherConditionCode.ClearSky, TimeOfDay.Night));
            weatherList.Add(NewMethod("03n",OpenWeatherMapApiClient.WeatherConditionCode.ScatteredClouds, TimeOfDay.Night));
            weatherList.Add(NewMethod("04n",OpenWeatherMapApiClient.WeatherConditionCode.OvercastClouds, TimeOfDay.Night));
            weatherList.Add(NewMethod("13n",OpenWeatherMapApiClient.WeatherConditionCode.Hail, TimeOfDay.Night));
            weatherList.Add(NewMethod("13n", OpenWeatherMapApiClient.WeatherConditionCode.Gale, TimeOfDay.Night));

            await SetWeather(weatherList[currentWeather]);

            if (currentWeather == 21)
                currentWeather = 0;
            else
                currentWeather++;
        }

        private Provider.OpenWeatherMap.WeatherData NewMethod(string icon, OpenWeatherMapApiClient.WeatherConditionCode weatherId, TimeOfDay timeOfDay)
        {
            var weatherData = new WeatherApp.Provider.OpenWeatherMap.WeatherData()
            {
                CityName = "Whatever",
                Date = DateTime.Now,
                Humidity = 60,
                Temperature = 25,
                WindSpeed = 5,
                WeatherID = weatherId,
                ImageID = icon
            };

            var semantic = new WeatherApp.Provider.OpenWeatherMap.OWMWeatherTypeConverter(weatherData);
            weatherData.ConditionType = semantic.GetSemantic();

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

            Icon = weatherAssetProvider.Icons[weatherData.ConditionType, weatherData.TimeOfDay];
            Background = weatherAssetProvider.Backgrounds[weatherData.ConditionType, weatherData.TimeOfDay];

            return weatherData;
        }
    }
}
