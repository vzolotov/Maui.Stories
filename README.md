# MAUI.Stories

is similar like Instagram Stories
## Nuget Package

To add __MAUI.Stories__ to your project, along with all its functionality, you can use the following command:

```
dotnet add package Pwa.Maui.Stories
```
## The easiest way to get started is this:
### in view model:
```cs
public class MainViewModel : IStoriesViewModel
{
    public ObservableCollection<StoriesImageViewModel> Items { get; set; } = new();
    public MainViewModel()
    {
        Items.Add(new StoriesImageViewModel("image1", new Uri("https://user-images.githubusercontent.com/4672627/152126443-932966cf-57e7-4e77-9be6-62463a66b9f8.png")));
        Items.Add(new StoriesImageViewModel("image2", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
        Items.Add(new StoriesImageViewModel("image3", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
    }
} 
```

### in view:

```xml
    <Page.DataContext>
        <demo:MainViewModel/> <-- set data context
    </Page.DataContext>
    <views:StoriesView
        x:Name="stories1" 
        IsStarted="True"
        DataContext="{Binding}"/>
```
