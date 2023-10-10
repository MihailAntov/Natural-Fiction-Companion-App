using NFCombat2.Models.Player;
namespace NFCombat2.Pages;

public partial class CharacterPage : ContentPage
{
	public CharacterPage()
	{
		InitializeComponent();
	}

	public async void ChangedClass(object sender, EventArgs e)
	{
        await DisplayAlert("Health", $"{StaticPlayer.Health}", "Okay");
    }
}