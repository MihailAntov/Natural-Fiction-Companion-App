using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class CharacterPage : ContentPage
{
	public CharacterPage(IProfileService profileService)
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

	public async void RegisterProfile(object sender, EventArgs e)
	{
		string name = ProfileName.Text;
		//_profileService.Save(name);
		await DisplayAlert("Successfully Added", $"{name}", "Okay");
	}

    public async void GetAllProfiles(object sender, EventArgs e)
    {
		//var profiles = _profileService.GetAll();
		//string result = string.Join(",", profiles.Select(x => $"{x.Name}, HP:{x.Health}"));
		//await DisplayAlert("profiles", result, "Okay");
    }
}