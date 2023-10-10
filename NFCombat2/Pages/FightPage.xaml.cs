using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;

namespace NFCombat2.Pages;

public partial class FightPage : ContentPage
{
	private Fight fight;
	private IFightService _fightService;
	
	public FightPage()
	{
		InitializeComponent();
    }
    

    public async void GetEpisode(object sender, EventArgs e)
	{
        int result = int.Parse(await DisplayPromptAsync("Enter episode number",null,"Enter","Cancel",null,maxLength:3,keyboard:Keyboard.Numeric));
		_fightService = this.Handler.MauiContext.Services.GetRequiredService<IFightService>();
		fight = await _fightService.GetFightByEpisodeNumber(result);
		TestLabel.Text = fight.GetType().Name;
    }

	public void IncreaseHealth(object sender, EventArgs e)
	{
		StaticPlayer.Health++;
	}

	public async void ShowHealth(object sender, EventArgs e)
	{
		await DisplayAlert("Health",$"{StaticPlayer.Health}","Okay");
	}

	


}