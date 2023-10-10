using NFCombat2.Models.Fights;
using NFCombat2.Services.Contracts;

namespace NFCombat2;

public partial class MainPage : ContentPage
{
	int count = 0;
	private Fight fight;
	//int episode = 0;

	public MainPage()
	{
		InitializeComponent();
		
	}



	private async void OnFightClicked(object sender, EventArgs e)
	{
		count++;
        var fightService = this.Handler.MauiContext.Services.GetRequiredService<IFightService>();

		

        
		if(!string.IsNullOrEmpty(episode.Text))
		{
			fight = await fightService.GetFightByEpisodeNumber(int.Parse(episode.Text));
            this.FightBtn.Text = fight.GetType().Name;
        }
     
		SemanticScreenReader.Announce(FightBtn.Text);
	}
}

