using Nkraft.MvvmEssentials.ViewModels;

namespace MauiApp1;

public class MainViewModel(HomeViewModel homeViewModel, SettingsViewModel settingsViewModel) : TabHostViewModel
{
	public override IReadOnlyCollection<TabViewModel> Tabs => [HomeViewModel, SettingsViewModel];

	public HomeViewModel HomeViewModel { get; } = homeViewModel;

	public SettingsViewModel SettingsViewModel { get; } = settingsViewModel;
}
