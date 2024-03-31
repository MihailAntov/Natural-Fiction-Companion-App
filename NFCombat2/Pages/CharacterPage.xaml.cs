using NFCombat2.Models.Player;
using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class CharacterPage : ContentPage
{
	public CharacterPage(IPlayerService profileService, IPopupService popupSerivce, INameService nameService)
	{
		InitializeComponent();
		BindingContext = new CharacterPageViewModel(profileService, popupSerivce,nameService);
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
				}
			}      
        }
    }






}