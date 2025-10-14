using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Nkraft.MvvmEssentials.Extensions;
using System.Reflection;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
			    .ConfigureMopups();

#if DEBUG
			builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(SemanticScreenReader.Default);

			builder.Services.AddTransient<HomeViewModel>();
			builder.Services.AddTransient<SettingsViewModel>();

			builder.Services.AddPageRegistry(registry =>
            {
				registry.MapPage<LandingPage, LandingViewModel>()
				    .MapPage<MainPage, MainViewModel>()
				    .MapPage<ConfirmPopup, ConfirmViewModel>()
					;
			});

			builder.Services.AddNavigationService(options =>
				options.AssemblyPageSource = Assembly.GetExecutingAssembly()
			);

			return builder.Build();
        }
    }
}
