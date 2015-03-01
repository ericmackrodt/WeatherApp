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
            WeatherData = await _weatherProvider.GetCurrentWeather(location.Point.Position.Latitude, location.Point.Position.Longitude, TemperatureUnit.Celsius);

            var sentence = await _sentenceProvider.GetSentence(WeatherData);
            SemanticWeather = sentence;
        }
    }
}
