using NFCombat2.Models.Player;
using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class CharacterPage : ContentPage
{
	public CharacterPage(IPlayerService profileService)
	{
		InitializeComponent();
		BindingContext = new CharacterPageViewModel(profileService);
	}
	

	public async void ChangedClass(object sender, EventArgs e)
	{
        if(BindingContext is CharacterPageViewModel viewModel)
		{
			viewModel.ChangedClass();
		}
    }

	public async void ChangedProfile(object sender, EventArgs e)
	{
        if (BindingContext is CharacterPageViewModel viewModel)
        {
			viewModel.ProcessChoice(sender);
            
        }
    }

	

    
}