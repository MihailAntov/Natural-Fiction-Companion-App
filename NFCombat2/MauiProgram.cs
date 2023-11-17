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

		
		builder.Services.AddSingleton<CharacterPage>();
		builder.Services.AddSingleton<FightPage>();
		builder.Services.AddSingleton<OptionPickerView>();
		builder.Services.AddSingleton<InventoryPage>();


		builder.Services.AddSingleton<InventoryPageViewModel>();
		builder.Services.AddSingleton<FightPageViewModel>();
		builder.Services.AddSingleton<OptionPickerViewModel>();
		builder.Services.AddSingleton<EntryWithSuggestionsViewModel>();

		string dbPath = FileAccessHelper.GetLocalFilePath("profiles.db3");
        builder.Services.AddSingleton<PlayerRepository>(s => ActivatorUtilities.CreateInstance<PlayerRepository>(s, dbPath));
        builder.Services.AddSingleton<FightRepository>(s => ActivatorUtilities.CreateInstance<FightRepository>(s, dbPath));
        builder.Services.AddSingleton<ItemRepository>(s => ActivatorUtilities.CreateInstance<ItemRepository>(s, dbPath));

        builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		SeedData();

		return builder.Build();
	}

    private static void SeedData()
    {
        string dbPath = FileAccessHelper.GetLocalFilePath("profiles.db3");

        // Assuming you've registered ItemRepository in the service collection
        var itemRepository = new ItemRepository(dbPath);
        ItemRepositorySeeder.SeedRepository(itemRepository);

        // Add additional seeding logic for other repositories if needed
    }
}
