using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

namespace ThemeEditor.Preview;

public class TabControlPage : UserControl
{
    public TabControlPage()
    {
        InitializeComponent();

        DataContext = new PageViewModel
        {
            Tabs = new[]
            {
                new TabItemViewModel
                {
                    Header = "Arch",
                    Text = "This is the first templated tab page."
                },
                new TabItemViewModel
                {
                    Header = "Leaf",
                    Text = "This is the second templated tab page."
                },
                new TabItemViewModel
                {
                    Header = "Disabled",
                    Text = "You should not see this.",
                    IsEnabled = false,
                },
            },
            TabPlacement = Dock.Top,
        };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private IBitmap LoadBitmap(string uri)
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        return new Bitmap(assets?.Open(new Uri(uri)));
    }

    private class PageViewModel : ReactiveObject
    {
        private Dock _tabPlacement;

        public TabItemViewModel[]? Tabs { get; set; }

        public Dock TabPlacement
        {
            get { return _tabPlacement; }
            set { this.RaiseAndSetIfChanged(ref _tabPlacement, value); }
        }
    }

    private class TabItemViewModel
    {
        public string? Header { get; set; }
        public string? Text { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
