using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecastLib
{
    public class WeatherForecastService
    {
        public async Task<WeatherForecastDocument> FetchForecastAsync(string cityId)
        {
            var http = new HttpClient();
            var uri = new OpenWeatherMapApi().GetServiceUri(cityId);
            var response = await http.GetAsync(uri);
            return await DeserializeOnSuccessAsync(response);
        }
        
        private static async Task<WeatherForecastDocument> DeserializeOnSuccessAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new WeatherForecastServiceResponseException(response);
            }

            var stream = await response.Content.ReadAsStreamAsync();
            var raw = DeserializeFromStream<dynamic>(stream);
            return new WeatherForecastDocument(raw);
        }

        private static T DeserializeFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var streamReader = new StreamReader(stream))
            using (var textReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<T>(textReader);
            }
        }
    }
}
