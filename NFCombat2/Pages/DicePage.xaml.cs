using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class DicePage : ContentPage
{
	public DicePage()
	{
		InitializeComponent();
		BindingContext = new DicePageViewModel();
		
	}
	
	public async void OnRoll(object sender, EventArgs e)
	{
        if (BindingContext is DicePageViewModel viewModel)
        {
            viewModel.Roll();
        }
    }

    public async void OnNumberOfDiceChanged(object sender, ValueChangedEventArgs e)
    {
        if (BindingContext is DicePageViewModel viewModel)
        {
            viewModel.NumberOfDice = (int)e.NewValue;
        }
    }

    public async void OnBonusDamageChanged(object sender, ValueChangedEventArgs e)
    {
        if (BindingContext is DicePageViewModel viewModel)
        {
            viewModel.BonusDamage = (int)e.NewValue;
        }
    }


}