using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeatherForecastTests
{
    [TestClass]
    public class CityServiceTests
    {
        [TestMethod]
        public async Task Known_city_should_be_found_with_case_insensitive_search()
        {
        }

        [TestMethod]
        public async Task Known_city_with_country_code_should_be_found_with_case_insensitive_search()
        {
        }

        [TestMethod]
        public async Task Unknown_city_should_throw()
        {
        }
    }
}
