using System.Collections.Generic;

namespace WeatherForecastLib
{
    public class WeatherForecastDocument
    {
        private readonly dynamic _obj;

        public WeatherForecastDocument(dynamic obj)
        {
            _obj = obj;
        }

        public string CityName => _obj.city.name;

        public string CountryCode => _obj.city.country;

        public IEnumerable<WeatherForecastItem> Items
        {
            get
            {
                foreach (var item in _obj.list)
                {
                    yield return new WeatherForecastItem(item);
                }
            }
        }
    }
}
