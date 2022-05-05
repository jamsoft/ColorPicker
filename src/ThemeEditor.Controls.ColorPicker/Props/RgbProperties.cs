﻿using System;
using Avalonia;
using ThemeEditor.Controls.ColorPicker.Colors;

namespace ThemeEditor.Controls.ColorPicker.Props;

public class RgbProperties : ColorPickerProperties
{
    public static readonly StyledProperty<byte> RedProperty =
        AvaloniaProperty.Register<RgbProperties, byte>(nameof(Red), 0xFF, validate: ValidateRed);

    public static readonly StyledProperty<byte> GreenProperty =
        AvaloniaProperty.Register<RgbProperties, byte>(nameof(Green), 0x00, validate: ValidateGreen);

    public static readonly StyledProperty<byte> BlueProperty =
        AvaloniaProperty.Register<RgbProperties, byte>(nameof(Blue), 0x00, validate: ValidateBlue);

    private static bool ValidateRed(byte red)
    {
        // ReSharper disable ConditionIsAlwaysTrueOrFalse
        if (red < 0 || red > 255) // ReSharper restore ConditionIsAlwaysTrueOrFalse
        {
            throw new ArgumentException("Invalid Red value.");
        }
        return true;
    }

    private static bool ValidateGreen(byte green)
    {
        // ReSharper disable ConditionIsAlwaysTrueOrFalse
        if (green < 0 || green > 255)
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
        {
            throw new ArgumentException("Invalid Green value.");
        }
        return true;
    }

    private static bool ValidateBlue(byte blue)
    {
        // ReSharper disable ConditionIsAlwaysTrueOrFalse
        if (blue < 0 || blue > 255)
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
        {
            throw new ArgumentException("Invalid Blue value.");
        }
        return true;
    }

    private bool _updating;

    public RgbProperties()
    {
        this.GetObservable(RedProperty).Subscribe(_ => UpdateColorPickerValues());
        this.GetObservable(GreenProperty).Subscribe(_ => UpdateColorPickerValues());
        this.GetObservable(BlueProperty).Subscribe(_ => UpdateColorPickerValues());
    }

    public byte Red
    {
        get => GetValue(RedProperty);
        set => SetValue(RedProperty, value);
    }

    public byte Green
    {
        get => GetValue(GreenProperty);
        set => SetValue(GreenProperty, value);
    }

    public byte Blue
    {
        get => GetValue(BlueProperty);
        set => SetValue(BlueProperty, value);
    }

    protected override void UpdateColorPickerValues()
    {
        if (_updating == false && Presenter != null)
        {
            _updating = true;
            var rgb = new RGB(Red, Green, Blue);
            var hsv = rgb.ToHSV();
            Presenter.Value1 = hsv.H;
            Presenter.Value2 = hsv.S;
            Presenter.Value3 = hsv.V;
            _updating = false;
        }
    }

    protected override void UpdatePropertyValues()
    {
        if (_updating == false && Presenter != null)
        {
            _updating = true;
            var hsv = new HSV(Presenter.Value1, Presenter.Value2, Presenter.Value3);
            var rgb = hsv.ToRGB();
            Red = (byte)rgb.R;
            Green = (byte)rgb.G;
            Blue = (byte)rgb.B;
            _updating = false;
        }
    }
}
