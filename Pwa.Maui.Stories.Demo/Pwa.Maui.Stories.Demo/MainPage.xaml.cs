namespace Pwa.Maui.Stories.Demo;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        stories1.IsStarted = true;
    }
}


