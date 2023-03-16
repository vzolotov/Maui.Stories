using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pwa.Maui.Stories.ViewModels
{
    /// <summary>
    /// Top line view model
    /// </summary>
    public partial class StoriesLineViewModel : ObservableObject
    {
        [ObservableProperty] ObservableCollection<StoriesImageViewModel> _source = new();
    }
}