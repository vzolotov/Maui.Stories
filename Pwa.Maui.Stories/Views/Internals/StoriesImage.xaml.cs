using Maui.BindableProperty.Generator.Core;

namespace Pwa.Maui.Stories.Views.Internals;

public partial class StoriesImage : StackLayout
{
    public StoriesImage()
    {
        InitializeComponent();
    }


    [AutoBindable] bool _isDescriptionVisible;
    [AutoBindable] double _previewHeight = 90;
}
