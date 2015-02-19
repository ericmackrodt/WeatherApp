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
                Temperature = 25.0,
                WindSpeed = 1,
                Humidity = 50,
                WeatherID = WeatherConditionCode.ClearSky,  
            };
            var sut = new SemanticWeather(data, TemperatureUnit.Celsius);
            var result = sut.GetSemantic();
            Assert.AreEqual(SemanticWeatherEnum.Nice, result);
        }

        [TestMethod]
        public void ShouldReturnClearHotCelsius()
        {
            var data = new WeatherData()
            {
                Temperature = 35.0,
                WindSpeed = 1,
                Humidity = 50,
                WeatherID = WeatherConditionCode.ClearSky,
            };
            var sut = new SemanticWeather(data, TemperatureUnit.Celsius);
            var result = sut.GetSemantic();
            Assert.AreEqual(SemanticWeatherEnum.Hot, result);
        }

        [TestMethod]
        public void ShouldReturnClearVeryHotCelsius()
        {
            var data = new WeatherData()
            {
                Temperature = 45.0,
                WindSpeed = 1,
                Humidity = 50,
                WeatherID = WeatherConditionCode.ClearSky,
            };
            var sut = new SemanticWeather(data, TemperatureUnit.Celsius);
            var result = sut.GetSemantic();
            Assert.AreEqual(SemanticWeatherEnum.VeryHot, result);
        }
    }
}
