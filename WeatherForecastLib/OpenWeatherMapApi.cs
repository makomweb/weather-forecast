namespace WeatherForecastLib
{
    public class OpenWeatherMapApi
    {
        private const string OpenWeatherMapApiKey = "85055d5565cd8433b7938052bb1c4e62"/* TODO Enter your Open Weather Map API key here! */; 

        public string GetServiceUri(string cityId)
        {
            return $"http://api.openweathermap.org/data/2.5/forecast?id={cityId}&APPID={OpenWeatherMapApiKey}";
        }
    }
}
