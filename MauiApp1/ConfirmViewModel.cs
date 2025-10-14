using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace MauiApp1;

record ConfirmResult(bool Confirm);

internal partial class ConfirmViewModel(IPopupService popupService) : PopupViewModel<ConfirmResult>(popupService)
{
	[RelayCommand]
	private async Task Yes()
	{
		await Dismiss(new ConfirmResult(true));
	}

	[RelayCommand]
	private async Task No()
	{
		await Dismiss(new ConfirmResult(false));
	}

	public string? ConfirmationMessage { get; set; }
}
