using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Extensions;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.Services.Navigation;
using Nkraft.MvvmEssentials.ViewModels;

namespace MauiApp1;

public partial class HomeViewModel(ISemanticScreenReader screenReader, IPopupService popupService) : TabViewModel
{
	private readonly ISemanticScreenReader _screenReader = screenReader;
	private readonly IPopupService _popupService = popupService;

	public override void OnTabSelected()
	{
		base.OnTabSelected();

		Console.WriteLine("Home tab selected");
	}

	public override void OnTabUnselected()
	{
		base.OnTabUnselected();

		Console.WriteLine("Bye!");
	}

	[RelayCommand]
	private async Task IncreaseCount()
	{
		Count++;

		if (Count == 1)
			CountButtonText = $"Clicked {Count} time";
		else
			CountButtonText = $"Clicked {Count} times";

		if (Count % 5 == 0)
		{
			var navParams = new NavigationParameters { { nameof(ConfirmViewModel.ConfirmationMessage), "Reset counter?" } };
			var result = await _popupService.PresentAsync<ConfirmViewModel, ConfirmResult>(navParams);
			if (result.TryGetValue(out var confirmResult))
			{
				Console.WriteLine("User pressed: {0}", confirmResult.Confirm ? "Yes" : "No");
				if (confirmResult.Confirm)
				{
					Count = 0;
				}
			}
			else
			{
				Console.WriteLine("User cancelled the popup");
			}
		}

		_screenReader.Announce(CountButtonText);
	}

	public int Count { get; set; }

	public string CountButtonText { get; set; } = "Click me";
}
