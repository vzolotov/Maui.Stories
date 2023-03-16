using System.Collections.ObjectModel;

namespace Pwa.Maui.Stories.ViewModels
{
    public interface IStoriesViewModel
    {
        ObservableCollection<StoriesImageViewModel> Items { get; set; }
    }
}