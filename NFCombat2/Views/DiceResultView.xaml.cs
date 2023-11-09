using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class DiceResultView : Popup
{
	public DiceResultView(DiceResultViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		CanBeDismissedByTappingOutsideOfPopup = false;
    }

    

    async void OnOkButtonClicked(object sender, EventArgs e) => await CloseAsync(false);
}