using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class ConfirmationPopupView : Popup
{
	public ConfirmationPopupView(ConfirmationPopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}