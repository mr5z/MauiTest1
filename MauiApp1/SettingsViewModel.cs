using Nkraft.MvvmEssentials.ViewModels;

namespace MauiApp1;

public class SettingsViewModel : TabViewModel
{
    protected override void OnTabSelected()
    {
        base.OnTabSelected();

        Console.WriteLine("Settings tab selected");
    }
}


