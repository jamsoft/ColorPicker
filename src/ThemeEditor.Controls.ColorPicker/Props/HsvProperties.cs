﻿using System;
using Avalonia;

namespace ThemeEditor.Controls.ColorPicker.Props;

public class HsvProperties : ColorPickerProperties
{
    public static readonly StyledProperty<double?> HueProperty =
        AvaloniaProperty.Register<HsvProperties, double?>(nameof(Hue), 0.0, validate: ValidateHue, coerce: CoerceHue);

    public static readonly StyledProperty<double?> SaturationProperty =
        AvaloniaProperty.Register<HsvProperties, double?>(nameof(Saturation), 100.0, validate: ValidateSaturation, coerce: CoerceSaturation);

    public static readonly StyledProperty<double?> ValueProperty =
        AvaloniaProperty.Register<HsvProperties, double?>(nameof(Value), 100.0, validate: ValidateValue, coerce: CoerceValue);

    private static double? CoerceHue(IAvaloniaObject arg1, double? arg2)
    {
        if (arg2 is null)
        {
            return null;
        }
        if (double.IsNaN(arg2.Value))
        {
            return 0.0;
        }
        return ColorPickerHelpers.Clamp(arg2.Value, 0.0, 360.0);
    }

    private static double? CoerceSaturation(IAvaloniaObject arg1, double? arg2)
    {
        if (arg2 is null)
        {
            return null;
        }
        if (double.IsNaN(arg2.Value))
        {
            return 0.0;
        }
        return ColorPickerHelpers.Clamp(arg2.Value, 0.0, 100.0);
    }

    private static double? CoerceValue(IAvaloniaObject arg1, double? arg2)
    {
        if (arg2 is null)
        {
            return null;
        }
        if (double.IsNaN(arg2.Value))
        {
            return 0.0;
        }
        return ColorPickerHelpers.Clamp(arg2.Value, 0.0, 100.0);
    }

    private static bool ValidateHue(double? hue)
    {
        if (hue < 0.0 || hue > 360.0)
        {
            return false;
        }
        return true;
    }

    private static bool ValidateSaturation(double? saturation)
    {
        if (saturation is null)
        {
            return true;
        }
        if (saturation < 0.0 || saturation > 100.0)
        {
            return false;
        }
        return true;
    }

    private static bool ValidateValue(double? value)
    {
        if (value is null)
        {
            return true;
        }
        if (value < 0.0 || value > 100.0)
        {
            return false;
        }
        return true;
    }

    private bool _updating;

    public HsvProperties()
    {
        this.GetObservable(HueProperty).Subscribe(_ => UpdateColorPickerValues());
        this.GetObservable(SaturationProperty).Subscribe(_ => UpdateColorPickerValues());
        this.GetObservable(ValueProperty).Subscribe(_ => UpdateColorPickerValues());
    }

    public double? Hue
    {
        get => GetValue(HueProperty);
        set => SetValue(HueProperty, value);
    }

    public double? Saturation
    {
        get => GetValue(SaturationProperty);
        set => SetValue(SaturationProperty, value);
    }

    public double? Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    protected override void UpdateColorPickerValues()
    {
        if (_updating == false && Presenter != null)
        {
            _updating = true;
            Presenter.Value1 = Hue;
            Presenter.Value2 = Saturation;
            Presenter.Value3 = Value;
            _updating = false;
        }
    }

    protected override void UpdatePropertyValues()
    {
        if (_updating == false && Presenter != null)
        {
            _updating = true;
            Hue = Presenter.Value1;
            Saturation = Presenter.Value2;
            Value = Presenter.Value3;
            _updating = false;
        }
    }
}
