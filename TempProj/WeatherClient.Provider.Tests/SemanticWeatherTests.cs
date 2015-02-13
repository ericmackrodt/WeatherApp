using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenWeatherMapApiClient;

namespace WeatherClient.Provider.Tests
{
    [TestClass]
    public class SemanticWeatherTests
    {
        [TestMethod]
        public void ShouldReturnClearNiceCelsius()
        {
            var data = new WeatherData() 
            {
                Temperature = 20.0,
                WeatherID = WeatherConditionCode.ClearSky,
                
            };
            var sut = new SemanticWeather(data, TemperatureUnit.Celsius);
            var result = sut.GetSemantic();
            Assert.AreEqual(result, SemanticWeatherEnum.Clear_Nice);
        }

        [TestMethod]
        public void ShouldReturnClearHotCelsius()
        {
            var data = new WeatherData()
            {
                Temperature = 30.0,
                WeatherID = WeatherConditionCode.ClearSky,

            };
            var sut = new SemanticWeather(data, TemperatureUnit.Celsius);
            var result = sut.GetSemantic();
            Assert.AreEqual(result, SemanticWeatherEnum.Clear_Hot);
        }

        [TestMethod]
        public void ShouldReturnClearVeryHotCelsius()
        {
            var data = new WeatherData()
            {
                Temperature = 40.0,
                WeatherID = WeatherConditionCode.ClearSky,

            };
            var sut = new SemanticWeather(data, TemperatureUnit.Celsius);
            var result = sut.GetSemantic();
            Assert.AreEqual(result, SemanticWeatherEnum.Clear_VeryHot);
        }
    }
}
