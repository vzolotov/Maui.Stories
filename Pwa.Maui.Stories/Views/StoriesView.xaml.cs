using Maui.BindableProperty.Generator.Core;
namespace Pwa.Maui.Stories.Views;

public partial class StoriesView : ContentView
{
    public StoriesView()
    {
        InitializeComponent();
    }

    [AutoBindable(OnChanged = nameof(OnIsStartedChanging))] bool _isStarted;

    private void OnIsStartedChanging(bool newValue)
    {
        if(newValue)
        {
            Start();
        }
        else
        {
            Stop();
        }
    }

    [AutoBindable] double _durationSeconds;
    [AutoBindable] bool _isDescriptionVisible;

    public void Start()
    {
        line?.Start();
    }

    public void Stop()
    {
        line?.Stop();
    }
}
