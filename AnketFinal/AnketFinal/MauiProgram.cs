using AnketFinal.Services;
using AnketFinal.ViewModel;
using AnketFinal.View;
using Microsoft.Extensions.Logging;

namespace AnketFinal;

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
		builder.Services.AddSingleton<AnketService>();
		builder.Services.AddSingleton<AnketsViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<QuestionsViewModel>();
		builder.Services.AddSingleton<QuestionsPage>();
        builder.Services.AddSingleton<QuestionsPage2>();

        return builder.Build();
	}
}
