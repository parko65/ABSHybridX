using ABSHybridX.ServiceTimers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;

namespace ABSHybridX
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddFluentUIComponents();

            builder.Services.AddSingleton<BackgroundTask>(sp => new BackgroundTask(TimeSpan.FromMilliseconds(1000)));

#if DEBUG
            var env = "Development";
#else
        var env = "Production";
#endif

            builder.Services.AddSingleton<IHostEnvironment>(sp =>
            new HostingEnvironment
            {
                EnvironmentName = env, // Or get from config
                ApplicationName = AppDomain.CurrentDomain.FriendlyName
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
