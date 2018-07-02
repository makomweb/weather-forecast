using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForecastLib
{
    public static class CityDeserializer
    {
        public static IEnumerable<City> Deserialize(string json)
        {
            var document = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (var city in document)
            {
                yield return new City(city);
            }
        }
    }
}
