using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForecastLib;

namespace WeatherForecastApp.ViewModels
{
    public class ForecastViewModel : ViewModelBase
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

        public ICommand SearchCommand => new RelayCommand(arg => OnSearch(arg as string));

        private async void OnSearch(string city)
        {
            Title = $"Weather in {city}";
            Date = DateTime.Now.ToString("D");

            try
            {
                var id = await GetCityId(city);

                Title = Title + id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private Task<int> GetCityId(string city)
        {
            if (city.Contains(','))
            {
                var parts = city.Split(',');

                return _cityService.GetCityIdAsync(parts[0].Trim(), parts[1].Trim());
            }

            return _cityService.GetCityIdAsync(city);
        }

        }
    }
}
