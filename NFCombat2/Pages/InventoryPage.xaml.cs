using NFCombat2.Models.Contracts;
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
				viewModel.GetItemDetails((IAddable)itemTapped.Item);
				if(sender is ListView listView)
				{
					listView.SelectedItem = null;
				}
			}
        }
    }

	public async void ChangedTab(object sender, CheckedChangedEventArgs e)
	{
		if(BindingContext is InventoryPageViewModel viewModel)
		{
			if (sender is RadioButton button)
			{
				
				viewModel.ChangeTabState((string)button.Value, button.IsChecked);
				
			}
		}
	}
	

}