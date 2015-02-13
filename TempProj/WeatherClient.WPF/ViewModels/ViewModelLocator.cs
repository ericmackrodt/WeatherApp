using Autofac;
using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClient.Provider;

namespace WeatherClient.WPF.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<OpenWeatherMapClient>().As<IOpenWeatherMapClient>();
            containerBuilder.RegisterType<WeatherProvider>().As<IWeatherProvider>();

            containerBuilder.RegisterType<MainViewModel>();

            _container = containerBuilder.Build();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}
