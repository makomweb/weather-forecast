using System;
using WeatherForecastLib;

namespace WeatherForecastApp.ViewModels
{
    public class ForecastDayItemViewModel
    {
        public string Time { get; }

        public string TemperatureMaximum { get; }

        public string TemperatureMinimum { get; }

        public string Description { get; }

        public string IconUri { get; }

        public ForecastDayItemViewModel(WeatherForecastItem item)
        {
            Time = item.TimeUtc.ToLocalTime().ToShortTimeString();
            TemperatureMinimum = $"{Math.Round(item.MinimumTemperatureCelsius, 1)} °C";
            TemperatureMaximum = $"{Math.Round(item.MaximumTemperatureCelsius, 1)} °C";
            Description = item.Description;
            IconUri = item.Icon;
        }
    }
}
