using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.ViewModels;

namespace MauiApp1;

public partial class HomeViewModel(ISemanticScreenReader screenReader) : TabViewModel
{
	private readonly ISemanticScreenReader _screenReader = screenReader;

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
	private void IncreaseCount()
	{
		Count++;

		if (Count == 1)
			CountButtonText = $"Clicked {Count} time";
		else
			CountButtonText = $"Clicked {Count} times";

		_screenReader.Announce(CountButtonText);
	}

	public int Count { get; set; }

	public string CountButtonText { get; set; } = "Click me";
}
