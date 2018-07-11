using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherForecastLib;

namespace WeatherForecastApp.ViewModels
{
    public class ForecastViewModel : NotifyPropertyChangedBase
    {
        private CityService _cityService;

        public ForecastViewModel()
        {
            var json = File.ReadAllText(@".\Data\city-codes.json");
            _cityService = new CityService(json);
        }

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title == value)
                    return;

                _title = value;
                NotifyPropertyChanged();
            }
        }

        private string _date;

        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (_date == value)
                    return;

                _date = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                NotifyPropertyChanged();
            }
        }

#if true // It's better to use command binding with can-execute from here!
        public ICommand SearchCommand => new RelayCommand(arg => OnSearch(arg as string),
                                                          arg => !string.IsNullOrWhiteSpace(arg as string));
#else
        public ICommand SearchCommand => new RelayCommand(arg => OnSearch(arg as string));
#endif
        private async void OnSearch(string city)
        {
            city = city.Trim();
            Title = $"Weather in {city}";
            Date = DateTime.Now.ToString("D");
            IsBusy = true;

            try
            {
                var id = await GetCityId(city);
                var service = new WeatherForecastService();
                var forecast = await service.FetchForecastAsync(id + "");
                Title = $"Weather in {forecast.CityName}, {forecast.CountryCode}";
                Publish(forecast);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ObservableCollection<ForecastDayViewModel> Days { get; } = new ObservableCollection<ForecastDayViewModel>();

        private Task<int> GetCityId(string city)
        {
            if (city.Contains(','))
            {
                var parts = city.Split(',');

                return _cityService.GetCityIdAsync(parts[0].Trim(), parts[1].Trim());
            }

            return _cityService.GetCityIdAsync(city);
        }

        private void Publish(WeatherForecastDocument doc)
        {
            var days = CreateDayViewModels(doc);
            Days.Clear();
            foreach (var d in days)
            {
                Days.Add(d);
            }
        }

        private static IEnumerable<ForecastDayViewModel> CreateDayViewModels(WeatherForecastDocument doc)
        {
            var groups = doc.Items.GroupBy(i => i.TimeUtc.ToLocalTime().Date).Select(x => x);

            foreach (var group in groups.Take(5))
            {
                var items = group.Select(i => new ForecastDayItemViewModel(i));
                yield return new ForecastDayViewModel(group.Key, items);
            }
        }
    }
}
