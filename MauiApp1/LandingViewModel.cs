using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using Nkraft.MvvmEssentials.Extensions;

namespace MauiApp1;

internal class LandingViewModel(INavigationService navigationService) : PageViewModel
{
	private readonly INavigationService _navigationService = navigationService;

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		int countdown = 5;

		while (countdown > 0)
		{
			CountdownText = $"In {countdown}...";
			countdown--;
			await Task.Delay(1_000);
		}

		await _navigationService.Absolute(withNavigation: false)
			.Push<MainViewModel, object>(new { SelectedTabIndex = 1 })
			.NavigateAsync();
	}

	protected override void OnDispose()
	{
		base.OnDispose();

		var a = 1;
		var b = a + 2;
	}

	public string? CountdownText { get; set; }
}
