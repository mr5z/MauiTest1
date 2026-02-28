using Nkraft.MvvmEssentials.Services.Navigation;
using Nkraft.MvvmEssentials.ViewModels;

namespace MauiApp1;

public class MainViewModel(HomeViewModel homeViewModel, SettingsViewModel settingsViewModel) : TabHostViewModel
{
	protected override IReadOnlyCollection<ITabComponent> Tabs => [HomeViewModel, SettingsViewModel];

	public HomeViewModel HomeViewModel { get; } = homeViewModel;

	public SettingsViewModel SettingsViewModel { get; } = settingsViewModel;
}
