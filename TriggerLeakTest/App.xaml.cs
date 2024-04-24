namespace TriggerLeakTest;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var style = new Style(typeof(HighMemoryPage));
        var trigger = new EventTrigger { Event = nameof(ContentPage.Appearing) };
        trigger.Actions.Add(new EmptyTriggerAction());
        style.Triggers.Add(trigger);

        Resources.Add(style);
        
        MainPage = new AppShell();
    }
}