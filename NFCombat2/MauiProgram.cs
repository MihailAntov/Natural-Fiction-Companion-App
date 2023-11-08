using NFCombat2.Services;
using Microsoft.Extensions.DependencyInjection;
using NFCombat2.Contracts;
using NFCombat2.Pages;
using NFCombat2.Data;
using NFCombat2.Views;
using NFCombat2.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;

namespace NFCombat2;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.Services.AddSingleton<IOptionsService, OptionsService>();
		builder.Services.AddSingleton<IFightService, FightService>();
		builder.Services.AddSingleton<IProfileService, ProfileService>();
		builder.Services.AddSingleton<ILogService, LogService>();
		builder.Services.AddSingleton<IPopupService, PopupService>();
		builder.Services.AddSingleton<IAccuracyService, AccuracyService>();

		
		builder.Services.AddSingleton<CharacterPage>();
		builder.Services.AddSingleton<FightPage>();
		builder.Services.AddSingleton<OptionPickerView>();

		builder.Services.AddSingleton<FightPageViewModel>();
		builder.Services.AddSingleton<OptionPickerViewModel>();

		string dbPath = FileAccessHelper.GetLocalFilePath("profiles.db3");
        builder.Services.AddSingleton<ProfileRepository>(s => ActivatorUtilities.CreateInstance<ProfileRepository>(s, dbPath));

        builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
