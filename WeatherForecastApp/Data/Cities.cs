using System.Collections.Generic;
using WeatherForecastLib;

namespace WeatherForecastApp.Data
{
    public class Cities : List<City>
    {
        public Cities(params City[] cities)
        {
            AddRange(cities);
        }
    }
}
