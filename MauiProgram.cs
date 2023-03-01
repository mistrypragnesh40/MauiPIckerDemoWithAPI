using DropDownDemoWithAPI.Services;
using DropDownDemoWithAPI.ViewModels;
using DropDownDemoWithAPI.Views;

namespace DropDownDemoWithAPI;

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

		//SErvices registration
		builder.Services.AddSingleton<ITestService, TestService>();

		//View MOdel registrations

		builder.Services.AddSingleton<DropDownDetailPageViewModel>();


		// pages registration
		builder.Services.AddSingleton<DropDownDetailPage>();
		return builder.Build();
	}
}
