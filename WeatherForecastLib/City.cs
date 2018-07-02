namespace WeatherForecastLib
{
    public class City
    {
        private dynamic _obj;

        public City(dynamic obj)
        {
            _obj = obj;
        }

        public int Id => _obj.id;

        public string Name => _obj.name;

        public string CountryCode => _obj.country;
    }
}
