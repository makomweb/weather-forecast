namespace WeatherForecastLib
{
    public class IconService
    {
        public string GetIconUri(string iconCode)
        {
            return $"http://openweathermap.org/img/w/{iconCode}.png";
        }
    }
}
