using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class MultipleChoicePopupView : Popup
{
	public MultipleChoicePopupView(MultipleChoicePopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		CanBeDismissedByTappingOutsideOfPopup = false;
	}
}