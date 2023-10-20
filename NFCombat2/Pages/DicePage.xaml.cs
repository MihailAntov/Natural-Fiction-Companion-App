namespace NFCombat2.Pages;

public partial class DicePage : ContentPage
{
	public DicePage()
	{
		InitializeComponent();
		BindingContext = this;
		random = new Random();
	}

	public int Dice { get; set; } = 1;
	public int BonusDamage { get; set; } = 0;

	public int Result { get; set; } = 0;
	public Random random;

    void OnDiceChanged(object sender, ValueChangedEventArgs e)
    {
        int value = (int)e.NewValue;
		Dice = value;
		OnPropertyChanged(nameof(Dice));
    }

	void OnBonusDamageChanged(object sender, ValueChangedEventArgs e)
	{
		int value = (int)e.NewValue;
		BonusDamage = value;
        OnPropertyChanged(nameof(BonusDamage));
    }

	void OnRoll(object sender, EventArgs e)
	{
		for (int i = 0; i < 6; i++)
        {
            var diceImage = this.FindByName($"DiceSlot{i}") as Image;
            diceImage.IsVisible = false;
			
        }

        this.ResultLabel.IsVisible = true;
		var dice = new List<int>();
		for(int i = 0; i < Dice; i++)
		{
			dice.Add(random.Next(1, 7));
		}


		for(int i = 0; i < dice.Count; i++)
		{
			int value = dice[i];
			var diceImage = this.FindByName($"DiceSlot{i}") as Image;
			diceImage.Source = $"dice{value}";
			diceImage.IsVisible = true;
		}

		Result = dice.Sum() + BonusDamage;

		OnPropertyChanged(nameof(Result));
	}

}