using Nkraft.MvvmEssentials.ViewModels;
using System.Collections.Immutable;

namespace MauiApp1;

public class MainViewModel(HomeViewModel homeViewModel, SettingsViewModel settingsViewModel) : TabHostViewModel
{
	public override ImmutableArray<TabViewModel> GetTabs() => [HomeViewModel, SettingsViewModel];

	public HomeViewModel HomeViewModel { get; } = homeViewModel;

	public SettingsViewModel SettingsViewModel { get; } = settingsViewModel;
}
