using NFCombat2.Services;
using Microsoft.Extensions.DependencyInjection;
using NFCombat2.Services.Contracts;
using NFCombat2.Pages;
using NFCombat2.Data;

namespace NFCombat2;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.Services.AddScoped<IOptionsService, OptionsService>();
		builder.Services.AddScoped<IFightService, FightService>();
		builder.Services.AddScoped<IProfileService, ProfileService>();
		builder.Services.AddSingleton<CharacterPage>();

		string dbPath = FileAccessHelper.GetLocalFilePath("profiles.db3");
        builder.Services.AddSingleton<ProfileRepository>(s => ActivatorUtilities.CreateInstance<ProfileRepository>(s, dbPath));

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
