using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecastLib;

namespace WeatherForecastTests
{
    [TestClass]
    public class WeatherForecastServiceTests
    {
        [TestMethod]
        public async Task Fetch_forecast_should_succeed()
        {
            var service = new WeatherForecastService();
            const string cityId = "2950159";
            var forecast = await service.FetchForecastAsync(cityId);
            Assert.IsNotNull(forecast);
        }
    }
}
