﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ThemeEditor.Preview;

public class BorderPage : UserControl
{
    public BorderPage()
    {
        this.InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}