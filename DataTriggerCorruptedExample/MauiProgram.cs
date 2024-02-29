using CommunityToolkit.Maui;
using DataTriggerCorruptedExample.Pages;
using DataTriggerCorruptedExample.Pages.Views;
using DataTriggerCorruptedExample.ViewModels;
using Microsoft.Extensions.Logging;
using Sharpnado.CollectionView;
using Sharpnado.Tabs;

namespace DataTriggerCorruptedExample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSharpnadoTabs(loggerEnable: false)
                .UseSharpnadoCollectionView(loggerEnable: false)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<TabView1>();
            builder.Services.AddSingleton<TabView1ViewModel>();

            builder.Services.AddTransient<TabView2>();
            builder.Services.AddTransient<TabView2ViewModel>();

            builder.Services.AddTransient<BottomSheetContentView>();

            return builder.Build();
        }
    }
}
