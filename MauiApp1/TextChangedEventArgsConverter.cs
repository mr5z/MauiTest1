using System.Globalization;

namespace MauiApp1;

public class TextChangedEventArgsConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => (value as TextChangedEventArgs)?.NewTextValue;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}