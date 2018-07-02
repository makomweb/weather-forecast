using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecastLib;

namespace WeatherForecastTests
{
    [TestClass]
    public class CityServiceTests
    {
        private CityService _service;

        [TestInitialize]
        public void Initialize()
        {
            var json = File.ReadAllText(@".\Data\city-codes.json");
            _service = new CityService(json);
        }

        [TestMethod]
        public async Task Known_city_should_be_found_with_case_insensitive_search()
        {
            var id = await _service.GetCityIdAsync("berlin");
            Assert.AreEqual(2950159, id);
        }

        [TestMethod]
        public async Task Known_city_with_country_code_should_be_found_with_case_insensitive_search()
        {
            var id = await _service.GetCityIdAsync("zurich", "ch");
            Assert.AreEqual(2657896, id);
        }

        [TestMethod]
        public async Task Unknown_city_should_throw()
        {
            const string unknownCityName = "Bruchtal";
            const string unknownCountryCode = "ME";

            try
            {
                await _service.GetCityIdAsync(unknownCityName, unknownCountryCode);
                Assert.Fail("Getting the city ID for an unknown city should have thrown already!");
            }
            catch (CityNotFoundException ex)
            {
                Assert.AreEqual(unknownCityName, ex.CityName, "Names should be equal!");
                Assert.AreEqual(unknownCountryCode, ex.CountryCode, "Country codes should be equal!");
            }
        }
    }
}
