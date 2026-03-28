using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.ViewModels;

namespace MauiApp1;

public partial class SettingsViewModel : TabViewModel
{
    protected override void OnInitialized()
    {
        base.OnInitialized();
        
        Items = GenerateItems();
    }

    protected override void OnTabSelected()
    {
        base.OnTabSelected();

        Console.WriteLine("Settings tab selected");
    }

    private CancellationTokenSource? cts;
    
    [RelayCommand(AllowConcurrentExecutions = true)]
    private async Task TextChanged(string? searchTerm)
    {
        try
        {
            if (cts is not null)
            {
                await cts.CancelAsync();
            }
            cts = new CancellationTokenSource();
            await Task.Delay(500, cts.Token);
            if (string.IsNullOrEmpty(searchTerm))
            {
                Items = GenerateItems();
            }
            else
            {
                Items = GenerateItems();
                Items = Items.Where(x => x.Title?.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) == true).ToArray();
            }
        }
        catch (TaskCanceledException) { }
    }

    private static Item[] GenerateItems()
    {
        return Enumerable.Range(0, 250).Select(i => new Item
        {
            Title = $"Item {i}",
            Description = $"Description {i}",
        }).ToArray();
    }

    public Item[] Items { get; set; } = [];
    
}


