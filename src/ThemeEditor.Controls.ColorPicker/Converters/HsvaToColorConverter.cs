﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;

namespace ThemeEditor.Controls.ColorPicker.Converters;

public class HsvaToColorConverter : IMultiValueConverter
{
    public static readonly HsvaToColorConverter Instance = new();

    public object Convert(IList<object?>? values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is { })
        {
            var v = values.OfType<double>().ToArray();
            if (v.Length == values.Count)
            {
                return ColorPickerHelpers.FromHSVA(v[0], v[1], v[2], v[3]);
            }
        }
        return AvaloniaProperty.UnsetValue;
    }
}
