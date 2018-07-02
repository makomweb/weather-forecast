using System;

namespace WeatherForecastLib
{
    public class CityNotFoundException : Exception
    {
        public string CityName { get; }

        public string CountryCode { get; }

        public CityNotFoundException(string cityName)
            : base(CreateMessage(cityName))
        {
            CityName = cityName;
        }

        public CityNotFoundException(string cityName, string countryCode)
            : base(CreateMessage(cityName, countryCode))
        {
            CityName = cityName;
            CountryCode = countryCode;
        }

        private static string CreateMessage(string cityName)
        {
            return $"The specified city '{cityName}' could not be found! Try adding a country code! E.g. Berlin, DE";
        }

        private static string CreateMessage(string cityName, string countryCode)
        {
            return $"The specified city '{cityName}, {countryCode}' could not be found!";
        }
    }
}
