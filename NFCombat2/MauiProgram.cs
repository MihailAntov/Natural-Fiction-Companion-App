using NFCombat2.Services;
using Microsoft.Extensions.DependencyInjection;
using NFCombat2.Contracts;
using NFCombat2.Pages;
using NFCombat2.Views;
using NFCombat2.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Data.Extensions;
using AutoMapper;
using NFCombat2.Data.Profiles;
using NFCombat2.Models.Notes;

namespace NFCombat2;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.Services.AddSingleton<IOptionsService, OptionsService>();
		builder.Services.AddSingleton<IFightService, FightService>();
		builder.Services.AddSingleton<IPlayerService, PlayerService>();
		builder.Services.AddSingleton<ILogService, LogService>();
		builder.Services.AddSingleton<IPopupService, PopupService>();
		builder.Services.AddSingleton<IAccuracyService, AccuracyService>();
		builder.Services.AddSingleton<IItemService, ItemService>();
		builder.Services.AddSingleton<INameService, NameService>();
		builder.Services.AddSingleton<INoteService, NoteService>();
		//builder.Services.AddSingleton<ISeederService, SeederService>();

		
		builder.Services.AddSingleton<CharacterPage>();
		builder.Services.AddSingleton<FightPage>();
		builder.Services.AddSingleton<OptionPickerView>();
		builder.Services.AddSingleton<InventoryPage>();
		builder.Services.AddSingleton<NotePage>();


		builder.Services.AddSingleton<InventoryPageViewModel>();
		builder.Services.AddSingleton<FightPageViewModel>();
		builder.Services.AddSingleton<OptionPickerViewModel>();
		builder.Services.AddSingleton<EntryWithSuggestionsViewModel>();
		builder.Services.AddSingleton<AddingProfileViewModel>();
		builder.Services.AddSingleton<NotePageViewModel>();
		builder.Services.AddSingleton<ConfirmationPopupViewModel>();
		builder.Services.AddSingleton<PartsBagViewModel>();
		builder.Services.AddSingleton<NotePageViewModel>();
		builder.Services.AddSingleton<NoteDetailsViewModel>();
		builder.Services.AddSingleton<FightRepository>();

		builder.Services.AddSingleton<Note>();
		string dbPath = FileAccessHelper.GetLocalFilePath("profiles.db3");
        builder.Services.AddSingleton<PlayerRepository>(s => ActivatorUtilities.CreateInstance<PlayerRepository>(s, dbPath,false));
		//TODO enable seeding only the first time
        //builder.Services.AddSingleton<FightRepository>(s => ActivatorUtilities.CreateInstance<FightRepository>(s, dbPath));
        builder.Services.AddSingleton<ItemRepository>(s => ActivatorUtilities.CreateInstance<ItemRepository>(s, dbPath));
        builder.Services.AddSingleton<SettingsRepository>(s => ActivatorUtilities.CreateInstance<SettingsRepository>(s, dbPath));
        //builder.Services.AddSingleton<NoteRepository>(s => ActivatorUtilities.CreateInstance<NoteRepository>(s, dbPath));
		builder.Services.AddAutoMapper(typeof(PlayerProfile));

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

    

	private static void ConfigureAutomapper()
	{

	}
}
