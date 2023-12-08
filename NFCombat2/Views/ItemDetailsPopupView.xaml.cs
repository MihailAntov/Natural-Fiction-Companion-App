using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class ItemDetailsPopupView : Popup
{
	public ItemDetailsPopupView(ItemDetailsPopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}