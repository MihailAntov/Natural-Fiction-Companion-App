using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class FightResultPopupView : Popup
{
	public FightResultPopupView(FightResultPopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		CanBeDismissedByTappingOutsideOfPopup = false;
	}
}