using NFCombat2.Services;
using Microsoft.Extensions.DependencyInjection;
using NFCombat2.Services.Contracts;

namespace NFCombat2;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.Services.AddScoped<IOptionsService, OptionsService>();
		builder.Services.AddScoped<IFightService, FightService>();

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
