using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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

        [TestMethod]
        public void Deserialize_forecast_should_succeed()
        {
            var doc = CreateDocument();
            AssertForecastDocument(doc);
        }

        private static WeatherForecastDocument CreateDocument()
        {
            var json = File.ReadAllText(@".\Data\weather-response-1.json");
            var raw = JsonConvert.DeserializeObject<dynamic>(json);
            return new WeatherForecastDocument(raw);
        }

        private static void AssertForecastDocument(WeatherForecastDocument forecast)
        {
            Assert.IsTrue(forecast.Items.Any(), "There should be any forecasts!");

            var item = forecast.Items.First();
            Assert.IsFalse(string.IsNullOrEmpty(item.Description), "Forecast item should have a description!");
            Assert.IsFalse(string.IsNullOrEmpty(item.Icon), "Forecast item should have an icon!");
        }
    }
}
