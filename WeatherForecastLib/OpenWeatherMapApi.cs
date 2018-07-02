namespace WeatherForecastLib
{
    public class OpenWeatherMapApi
    {
        private const string OpenWeatherMapApiKey = /* TODO Enter your Open Weather Map API key here! */; 

        public string GetServiceUri(string cityId)
        {
            return $"http://api.openweathermap.org/data/2.5/forecast?id={cityId}&APPID={OpenWeatherMapApiKey}";
        }
    }
}
