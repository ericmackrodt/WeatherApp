using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Provider.Tests
{
    [TestClass]
    public class ApparentTemperatureCalculatorTests
    {
        [TestMethod]
        public void ShouldCalculate()
        {
            var data = new WeatherData()
            {
                Temperature = 3.0,
                WindSpeed = 2.2,
                Humidity = 45
            };
            var sut = new ApparentTemperatureCalculator(data, SpeedUnit.Kmh);
            var result = sut.GetApparentWeather();
            Assert.AreEqual(30, result);
        }
    }
}
