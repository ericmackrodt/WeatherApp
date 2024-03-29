﻿using Autofac;
using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Common;
using WeatherApp.Provider;
using WeatherApp.Provider.OpenWeatherMap;
using WeatherApp.Provider.Sentences;
using WeatherApp.Settings;

namespace WeatherApp.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OpenWeatherMapSettings>().As<IOpenWeatherMapSettings>();
            builder.RegisterType<LocationProvider>().As<ILocationProvider>();
            builder.RegisterType<OpenWeatherMapClient>().As<IOpenWeatherMapClient>();
            builder.RegisterType<OpenWeatherMapProvider>().As<IWeatherProvider>();
            builder.RegisterType<WittySentencesProvider>().As<ISentenceProvider>();

            builder.RegisterType<MainViewModel>();

            _container = builder.Build();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}
