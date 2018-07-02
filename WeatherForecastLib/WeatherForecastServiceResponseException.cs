using System;
using System.Net;
using System.Net.Http;

namespace WeatherForecastLib
{
    public class WeatherForecastServiceResponseException : Exception
    {
        private HttpResponseMessage _message;

        public WeatherForecastServiceResponseException(HttpResponseMessage message)
        {
            _message = message;
        }

        public string RequestUri => _message.RequestMessage.RequestUri.ToString();

        public HttpStatusCode StatusCode => _message.StatusCode;

        public HttpContent ResponseContent => _message.Content;
    }
}
