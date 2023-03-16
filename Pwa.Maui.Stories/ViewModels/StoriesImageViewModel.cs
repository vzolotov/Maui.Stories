using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pwa.Maui.Stories.ViewModels
{
    public partial class StoriesImageViewModel : ObservableObject, IStoriesImage
    {
        /// <summary>
        /// Image view model
        /// </summary>
        /// <param name="text">image description</param>
        /// <param name="image">image url</param>
        public StoriesImageViewModel(string text, Uri image)
        {
            Text = text;
            Image = image;
        }

        [ObservableProperty] string? _text;
        [ObservableProperty] Uri _image;
        [ObservableProperty] bool _isStarted = false;

    }
}