using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class InventoryPage : ContentPage
{
	public InventoryPage(InventoryPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	public async void TappedItem(object sender, EventArgs e)
	{
		//todo : implement equipping modifications
		if(BindingContext is InventoryPageViewModel viewModel)
		{
            if (e is ItemTappedEventArgs itemTapped)
            {
                viewModel.UsedItem(itemTapped.Item);
            } 
        }
	}

	public async void TappedEquipment(object sender, EventArgs e)
	{
        if (BindingContext is InventoryPageViewModel viewModel)
        {
			if(e is ItemTappedEventArgs itemTapped)
			{
				viewModel.UsedEquipment(itemTapped.Item);
			}
        }
    }
	

}