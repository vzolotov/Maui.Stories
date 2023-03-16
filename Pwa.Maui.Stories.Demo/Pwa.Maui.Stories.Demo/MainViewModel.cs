using System;
using System.Collections.ObjectModel;
using Pwa.Maui.Stories.ViewModels;

namespace Pwa.Maui.Stories.Demo
{
    public class MainViewModel : IStoriesViewModel
    {
        public ObservableCollection<StoriesImageViewModel> Items { get; set; } = new();
        public MainViewModel()
        {
            Items.Add(new StoriesImageViewModel("image1", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
            Items.Add(new StoriesImageViewModel("image2", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
            Items.Add(new StoriesImageViewModel("image3", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
        }
    }
}

