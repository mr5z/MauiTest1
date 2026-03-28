using PropertyChanged;

namespace MauiApp1;

[AddINotifyPropertyChangedInterface]
public class Item
{
    public string? Title { get; init; }

    public string? Description { get; init; }

    public bool IsVisible { get; set; } = true;
}