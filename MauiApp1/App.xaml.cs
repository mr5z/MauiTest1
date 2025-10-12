using Microsoft.Extensions.Logging;
using Nkraft.MvvmEssentials.Extensions;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.Services.Navigation;

namespace MauiApp1;

public partial class App
{
	private readonly ILogger<App> _logger;
	private readonly INavigationService _navigationService;
	private readonly IWindowEventHandler _windowEvent;

	public App(ILogger<App> logger, INavigationService navigationService, IWindowEventHandler windowEvent)
	{
		_logger = logger;
		_navigationService = navigationService;
		_windowEvent = windowEvent;

		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		// I know Task is not awaited.
		// I actually don't know where is the better place to do this.
		// Help needed, please 🙏.

		var result = _navigationService.Absolute(withNavigation: false)
			.Push<MainViewModel>() // replace with whatever first ViewModel your app should use
			.NavigateAsync()
			.GetAwaiter()
			.GetResult();

		if (result.IsFailure)
		{
			_logger.LogError(result.ErrorMessage);
			Application.Current?.Quit();
			throw new Exception($"Application quitting due to: {result.ErrorMessage}");
		}

		var window = base.CreateWindow(activationState);

		window.Created += (s, e) => _windowEvent.OnCreated();
		window.Destroying += (s, e) => _windowEvent.OnDestroying();
		window.Activated += (s, e) => _windowEvent.OnActivated();
		window.Deactivated += (s, e) => _windowEvent.OnDeactivated();
		window.Resumed += (s, e) => _windowEvent.OnResumed();
		window.Stopped += (s, e) => _windowEvent.OnStopped();

		return window;
	}

}