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



	private void OnFightClicked(object sender, EventArgs e)
	{
		count++;
        var fightService = this.Handler.MauiContext.Services.GetRequiredService<IFightService>();

		//if(fight == null)
		//{
			
		//	fight = fightService.GetFightByEpisodeNumber(int.Parse(episode.Text));
		//}

        
		if(!string.IsNullOrEmpty(episode.Text))
		{
			fight = fightService.GetFightByEpisodeNumber(int.Parse(episode.Text));
            this.FightBtn.Text = fight.GetType().Name;
        }
        

        //fight.Enemies.Add(new Models.Enemy());



        //if (count == 1)
        //{
        //	this.FightBtn.Text = $"Fought {count} time";
        //}
        //else
        //{
        //	this.FightBtn.Text = $"Fought {count} times";
        //}

        
		SemanticScreenReader.Announce(FightBtn.Text);
	}
}

