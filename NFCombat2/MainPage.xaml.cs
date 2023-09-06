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

