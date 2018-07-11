using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeatherForecastApp.Views
{
    /// <summary>
    /// Interaction logic for CityEditTextBox.xaml
    /// </summary>
    public partial class CityEditTextBox : UserControl
    {
        public CityEditTextBox()
        {
            InitializeComponent();
            InnerTextBox.PreviewKeyDown += OnPreviewKeyDown;
        }

        public static readonly DependencyProperty IsSpaceAllowedProperty = DependencyProperty.Register("IsSpaceAllowed", typeof(bool), typeof(CityEditTextBox));

        public bool IsSpaceAllowed
        {
            get { return (bool)GetValue(IsSpaceAllowedProperty); }
            set { SetValue(IsSpaceAllowedProperty, value); }
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs args)
        {
            base.OnPreviewKeyDown(args);
            if (!IsSpaceAllowed && (args.Key == Key.Space))
            {
                args.Handled = true;
            }
        }
    }
}
