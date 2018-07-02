using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecastLib
{
    public class WeatherForecastService
    {
        public Task<HttpResponseMessage> FetchForecastAsync(string cityId)
        {
            var http = new HttpClient();
            var uri = new OpenWeatherMapApi().GetServiceUri(cityId);
            return http.GetAsync(uri);
        }
    }
}
