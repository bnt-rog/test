using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PTR_DRS.Repositories;
using PTR_DRS.ViewModels;
using PTR_DRS.Views;
using UraniumUI;

namespace PTR_DRS;

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
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddUraniumUIHandlers();
            })
            .UseMauiCommunityToolkit();

        builder.Services.AddSingleton<RideRepository>();
        builder.Services.AddSingleton<RiderRepository>();

        builder.Services.AddSingleton<BaseViewModel>();
        builder.Services.AddSingleton<RideViewModel>();
        builder.Services.AddSingleton<RiderViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<RidePage>();
        builder.Services.AddSingleton<RiderPage>();

        return builder.Build();
	}
}
