using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using NoteMauiBlazorWasm.Common.Interfaces;
using NoteMauiBlazorWasm.Common.Services;
using NoteMauiBlazorWasm.Data;
using NoteMauiBlazorWasm.Services;

namespace NoteMauiBlazorWasm
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
                })
                .UseMauiCommunityToolkit();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<AuthServices>();
            builder.Services.AddSingleton<IAlertService, AlertService>()
                            .AddSingleton<IStorageService, StorageService>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}