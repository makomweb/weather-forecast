using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WeatherForecastApp
{
    public abstract class NotifyDataErrorInfoBase : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        
        protected void NotifyErrorsChanged([CallerMemberName] string propertyName = "")
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
            {
                return Enumerable.Empty<string>();
            }

            return _errors[propertyName];
        }

        protected void Validate(bool isValid, [CallerMemberName] string propertyName = "")
        {
            if (isValid)
            {
                _errors.Remove(propertyName);
            }
            else
            {
                _errors[propertyName] = new List<string> { "Not valid!" };
            }

            NotifyErrorsChanged(propertyName);
        }
    }
}
