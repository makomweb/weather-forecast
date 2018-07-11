using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using WeatherForecastLib;

namespace WeatherForecastApp
{
    public class CityInputValidationRule : ValidationRule
    {
        private CityService _cityService;

        public CityInputValidationRule()
        {
            var json = File.ReadAllText(@".\Data\city-codes.json");
            _cityService = new CityService(json);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return ValidateAsync(value as string).Result;
        }

        private async Task<ValidationResult> ValidateAsync(string city)
        {
            if (city != null)
            {
                try
                {
                    await _cityService.GetCityIdAsync(city);
                }
                catch (CityNotFoundException ex)
                {
                    return new ValidationResult(false, $"No such city like '{city}'!\n{ex}");
                }
                catch (Exception ex)
                {
                    return new ValidationResult(false, $"Exception caught while getting city id for $'{city}'!\n{ex}");
                }
            }

            return new ValidationResult(false, "Argument 'value' is not of type string!");
        }
    }
}
