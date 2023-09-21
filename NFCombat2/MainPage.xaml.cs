using NFCombat2.Models.Fights;
using NFCombat2.Services.Contracts;

namespace NFCombat2;

public partial class MainPage : ContentPage
{
	int count = 0;
	
	

	public MainPage()
	{
		InitializeComponent();
		
	}



	private void OnFightClicked(object sender, EventArgs e)
	{
		count++;
        var fightService = this.Handler.MauiContext.Services.GetRequiredService<IFightService>();
		var fight = fightService.GetFightByEpisodeNumber(count);




		//if (count == 1)
		//{
		//	this.FightBtn.Text = $"Fought {count} time";
		//}
		//else
		//{
		//	this.FightBtn.Text = $"Fought {count} times";
		//}

		this.FightBtn.Text = fight.GetType().Name;
		SemanticScreenReader.Announce(FightBtn.Text);
	}
}

