using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;

namespace NFCombat2.Pages;

public partial class CharacterPage : ContentPage
{
	private IProfileService _profileService;
	public CharacterPage()
	{
		InitializeComponent();
	}
	public CharacterPage(IProfileService profileService) : base()
	{
		InitializeComponent();
		_profileService = profileService;
	}

	public async void ChangedClass(object sender, EventArgs e)
	{
        await DisplayAlert("Health", $"{StaticPlayer.Health}", "Okay");
    }

	public async void RegisterProfile(object sender, EventArgs e)
	{
		string name = ProfileName.Text;
		_profileService.Save(name);
		await DisplayAlert("Successfully Added", $"{name}", "Okay");
	}

    public async void GetAllProfiles(object sender, EventArgs e)
    {
		var profiles = _profileService.GetAll();
		string result = string.Join(",", profiles.Select(x => $"{x.Name}, HP:{x.Health}"));
		await DisplayAlert("profiles", result, "Okay");
    }
}