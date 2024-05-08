using System.Globalization;

namespace SampleMauiApp.Converters
{
    public class IntToBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue > 0;
            }
            return false; // Default to false if value is not an int
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // ConvertBack is not needed for this converter
            throw new NotImplementedException();
        }
    }
}
