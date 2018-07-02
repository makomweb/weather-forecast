using System;
using System.Collections.Generic;

namespace WeatherForecastApp.ViewModels
{
    public class ForecastDayViewModel
    {
        public string Weekday { get; }

        public string Date { get; }

        public IEnumerable<ForecastDayItemViewModel> Items { get; }

        public ForecastDayViewModel(DateTime day, IEnumerable<ForecastDayItemViewModel> items)
        {
            Weekday = string.Format("{0:dddd}", day.ToLocalTime());
            Date = day.ToLocalTime().ToString("M");
            Items = items;
        }
    }
}
