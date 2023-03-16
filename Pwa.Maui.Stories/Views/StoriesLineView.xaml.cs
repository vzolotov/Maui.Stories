using System.Collections.ObjectModel;
using System.Windows.Input;
using Pwa.Maui.Stories.ViewModels;
using Maui.BindableProperty.Generator.Core;
using Pwa.Maui.Stories.Views.Internals;

namespace Pwa.Maui.Stories.Views;

public partial class StoriesLineView : ContentView
{
    public event EventHandler<StoriesImageViewModel?> CurrentItemChanging;

    public StoriesLineView()
    {
        InitializeComponent();
    }

    [AutoBindable] ObservableCollection<StoriesImageViewModel>? _items;
    [AutoBindable(OnChanged = nameof(OnCurrentItemChanging))] StoriesImageViewModel? _currentItem;
    [AutoBindable] int _selectedIndex = 0;
    [AutoBindable] ICommand? _itemTapCommand;
    [AutoBindable] double _durationSeconds;
    [AutoBindable] bool _isDescriptionVisible;

    public void Start()
    {
        if(CurrentItem == null)
        {
            CurrentItem = Items?.FirstOrDefault();
        }
        else
        {
            CurrentItem.IsStarted = true;
        }
    }

    public void Stop()
    {
        if(CurrentItem != null) CurrentItem.IsStarted = false;
    }

    private void OnCurrentItemChanging(StoriesImageViewModel newValue)
    {
        SelectedIndex = Items?.IndexOf(newValue) ?? 0;
        CurrentItemChanging?.Invoke(this, CurrentItem);
        ItemTapCommand?.Execute(CurrentItem);
    }
    private void InputElement_OnTapped(object sender, TappedEventArgs e)
    {
        if(!(sender is StackLayout panel)) return;
        if(panel.BindingContext == null) return;

        var story = panel.BindingContext as StoriesImageViewModel;
        if(CurrentItem == story)
        {
            CurrentItem.IsStarted = !CurrentItem.IsStarted;
        }
        else
        {
            CurrentItem.IsStarted = false;
            CurrentItem = story;
            CurrentItem.IsStarted = true;
        }
    }

    private void StoriesAnimatedBar_OnCompleted(object sender, EventArgs e)
    {
        var bar = sender as StoriesAnimatedBar;
        if(Items != null && bar?.BindingContext is StoriesImageViewModel story && story != Items.Last())
        {
            CurrentItem = Items[SelectedIndex + 1];
        }
    }
}
