using System.ComponentModel;
using System.Globalization;

namespace TriggerLeakTest;

public partial class MainPage : ContentPage
{
    readonly Label _heapSizeDisplay;

    public MainPage()
    {
        InitializeComponent();

        _heapSizeDisplay = new Label();

        var button = new Button
        {
            Text = "Nav"
        };
        button.Pressed += ButtonOnPressed;

        Content = new VerticalStackLayout
        {
            new Label
            {
                Text = "HeapSize MB"
            },
            _heapSizeDisplay,
            button
        };
    }

    void ButtonOnPressed(object? sender, EventArgs e)
    {
        _ = Navigation.PushAsync(new HighMemoryPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _heapSizeDisplay.Text = (GC.GetTotalMemory(true) / 1024d / 1024d).ToString(CultureInfo.InvariantCulture);
    }
}