using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastLib
{
    public class CityService
    {
        public IEnumerable<City> Cities { get; }

        public CityService(string json)
        {
            Cities = CityDeserializer.Deserialize(json);
        }

        public Task<int> GetCityIdAsync(string cityName)
        {
            return Task.Run(() => GetCityId(cityName));
        }

        public Task<int> GetCityIdAsync(string cityName, string countryCode)
        {
            return Task.Run(() => GetCityId(cityName, countryCode));
        }

        private int GetCityId(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                throw new ArgumentException("Argument is null or whitespace", "cityName");
            }

            var city = Cities.FirstOrDefault(c => string.Compare(c.Name, cityName, true) == 0);
            return city.Id;
        }

        private int GetCityId(string cityName, string countryCode)
        {
            var city = Cities.FirstOrDefault(c => IsSameCity(c, cityName, countryCode));
            return city.Id;
        }

        /// <summary>
        /// Check if the specified city matches the city name
        /// and the country code using case insensitve comparision.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="otherCityName"></param>
        /// <param name="otherCountryCode"></param>
        /// <returns></returns>
        private static bool IsSameCity(City one, string otherCityName, string otherCountryCode)
        {
            return (string.Compare(one.Name, otherCityName, true) == 0) &&
                   (string.Compare(one.CountryCode, otherCountryCode, true) == 0);
        }
    }
}
