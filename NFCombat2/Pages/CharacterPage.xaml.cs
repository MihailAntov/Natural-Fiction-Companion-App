using NFCombat2.Models.Player;
using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class CharacterPage : ContentPage
{
	private readonly IPlayerService _playerService;
    //public CharacterPage(IPlayerService playerService, IPopupService popupSerivce, INameService nameService, SettingsPageViewModel settingsPageViewModel, ISettingsService settingsService)
    //{
    //	InitializeComponent();
    //	BindingContext = new CharacterPageViewModel(playerService, popupSerivce,nameService,settingsPageViewModel, settingsService);
    //	_playerService = playerService;
    //}
    public CharacterPage(CharacterPageViewModel viewModel, IPlayerService playerService)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _playerService = playerService;
    }


    public async void ChangedProfile(object sender, EventArgs e)
	{
        if (BindingContext is CharacterPageViewModel viewModel)
        {
			if(sender is Picker picker)
			{
				if(picker.SelectedItem != null)
				{
					viewModel.ProcessChoice(picker.SelectedItem);
					picker.SelectedItem = null;
				}
			}      
        }
    }


    protected override async void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
		await _playerService.SavePlayer();
        base.OnNavigatedFrom(args);
    }

  




}