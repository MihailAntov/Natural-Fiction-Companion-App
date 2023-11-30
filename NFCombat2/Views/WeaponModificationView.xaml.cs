using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class WeaponModificationView : Popup
{
	public WeaponModificationView(WeaponModificationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}