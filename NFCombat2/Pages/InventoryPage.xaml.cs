using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class InventoryPage : ContentPage
{
	public InventoryPage(InventoryPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}