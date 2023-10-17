using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;
using CommunityToolkit.Maui.Views;

namespace NFCombat2.Pages;

public partial class FightPage : ContentPage
{
	private Fight fight;
	private IFightService _fightService;
	private IOptionsService _optionsService;
	
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
		this.ShowHpBtn.IsVisible = true;
		this.IncreaseHpBtn.IsVisible = true;
		this.ChooseStandardActionBtn.IsVisible = true;
    }

	public void IncreaseHealth(object sender, EventArgs e)
	{
		StaticPlayer.Health++;
	}

	public async void ShowHealth(object sender, EventArgs e)
	{
		await DisplayAlert("Health",$"{StaticPlayer.Health}","Okay");
	}

	public async void ShowStandardOptions(object sender, EventArgs e)
	{
        _optionsService = this.Handler.MauiContext.Services.GetRequiredService<IOptionsService>();
		var standardActionOptions = _optionsService.GetStandardActionOptions(this.fight);
		var optionsPage = new ChooseStandardAction(standardActionOptions);
		
		
		await Navigation.PushAsync(optionsPage);
    }

	


}