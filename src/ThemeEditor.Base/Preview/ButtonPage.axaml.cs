﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ThemeEditor.Preview;

public class ButtonPage : UserControl
{
    public ButtonPage()
    {
        this.InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}