using Microsoft.Extensions.Logging;
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(SemanticScreenReader.Default);

			builder.Services.AddTransient<HomeViewModel>();
			builder.Services.AddTransient<SettingsViewModel>();

			builder.Services.AddPageRegistry(registry =>
            {
				registry.MapPage<MainPage, MainViewModel>()
					;
			});

			builder.Services.AddNavigationService(options =>
				options.AssemblyPageSource = Assembly.GetExecutingAssembly()
			);

			return builder.Build();
        }
    }
}
