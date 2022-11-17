using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Alfheim.Converters;

public class DoublesToColorConverter: IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        return Equals((double?)values[0], (double?)values[1]) ? Brushes.Blue : Brushes.Yellow;
    }
}