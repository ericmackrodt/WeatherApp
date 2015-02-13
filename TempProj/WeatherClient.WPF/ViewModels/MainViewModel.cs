using MVVMBasic;
using MVVMBasic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherClient.Provider;

namespace WeatherClient.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IWeatherProvider _provider;

        private string _weatherLocation;
        public string WeatherLocation
        {
            get { return _weatherLocation; }
            set
            {
                _weatherLocation = value;
                NotifyChanged();
            }
        }

        private double _temperature;
        public double Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                NotifyChanged();
            }
        }

        private double _apparentTemperature;
        public double ApparentTemperature
        {
            get { return _apparentTemperature; }
            set
            {
                _apparentTemperature = value;
                NotifyChanged();
            }
        }

        private string _weatherCondition;
        public string WeatherCondition
        {
            get { return _weatherCondition; }
            set
            {
                _weatherCondition = value;
                NotifyChanged();
            }
        }

        private double _humidity;
        public double Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                NotifyChanged();
            }
        }

        private double _windSpeed;
        public double WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                _windSpeed = value;
                NotifyChanged();
            }
        }

        private WeatherIconType _iconType;
        public WeatherIconType IconType
        {
            get { return _iconType; }
            set
            {
                _iconType = value;
                NotifyChanged();
            }
        }

        private ICommand _getWeatherCommand;        
        public ICommand GetWeatherCommand
        {
            get { return _getWeatherCommand; }
        }

        public MainViewModel(IWeatherProvider provider)
        {
            _provider = provider;

            _getWeatherCommand = new AsyncRelayCommand(GetWeather);
        }

        private async Task GetWeather(object arg)
        {
            var weather = await _provider.GetCurrentWeather(_weatherLocation, TemperatureUnit.Celsius);
            Temperature = Math.Round(weather.Temperature, 1);
            ApparentTemperature = _provider.GetApparentTemperature(weather);
            WeatherCondition = weather.WeatherID.ToString();
            Humidity = weather.Humidity;
            WindSpeed = weather.WindSpeed;
            IconType = weather.IconType;
        }

        public override async Task LoadData(object arg)
        {
            WeatherLocation = "Rio de Janeiro,BR";
            await GetWeather(null);
        }
    }
}
