using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;
using LiveChartsCore.SkiaSharpView.Maui;
using FamilyManager.Services;
using FamilyManager.ViewModels;

namespace FamilyManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // CHÚ Ý: Phải gọi hàm này để dùng được CommunityToolkit
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .UseLiveCharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Đăng ký DatabaseService
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<Views.LoginPage>(); // Chú ý namespace Views
            builder.Services.AddTransient<Views.MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}