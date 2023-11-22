using NFCombat2.Models.Player;
using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class CharacterPage : ContentPage
{
	public CharacterPage(IPlayerService profileService, IPopupService popupSerivce)
	{
		InitializeComponent();
		BindingContext = new CharacterPageViewModel(profileService, popupSerivce);
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