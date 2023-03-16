using System;

namespace Pwa.Maui.Stories.ViewModels
{
    public interface IStoriesImage
    {
        string? Text { get; set; }
        Uri Image { get; set; }
    }
}