using System;

namespace WeatherForecastLib
{
    public class WeatherForecastItem
    {
        private dynamic _obj;

        public WeatherForecastItem(dynamic obj)
        {
            _obj = obj;
        }

        public DateTime TimeUtc
        {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return epoch.AddSeconds((int)_obj.dt);
            }
        }
        public double MinimumTemperatureCelsius
        {
            get
            {
                var value = (double)_obj.main.temp_min;
                return value - 273.15;
            }
        }

        public double MaximumTemperatureCelsius
        {
            get
            {
                var value = (double)_obj.main.temp_max;
                return value - 273.15;
            }
        }

        public string Description => _obj.weather[0].description;

        public string Icon => _obj.weather[0].icon;
    }
}
