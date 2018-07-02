using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WeatherForecastApp.ViewModels
{
    public class ForecastViewModel : ViewModelBase
    {
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

        private void OnSearch(string city)
        {
            Title = $"Weather in {city}";
            Date = DateTime.Now.ToString("D");           
        }
    }
}
