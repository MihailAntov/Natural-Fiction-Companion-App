using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class InventoryPage : ContentPage
{
	private readonly IPlayerService _playerService;
	public InventoryPage(InventoryPageViewModel viewModel, IPlayerService playerService)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_playerService = playerService;
	}

	public async void TappedItem(object sender, EventArgs e)
	{
		if(BindingContext is InventoryPageViewModel viewModel)
		{
            if (e is ItemTappedEventArgs itemTapped)
            {
                viewModel.GetItemDetails((IAddable)itemTapped.Item);
                if (sender is ListView listView)
                {
                    listView.SelectedItem = null;
                }
            } 
        }
	}

	//public async void TappedEquipment(object sender, EventArgs e)
	//{
 //       if (BindingContext is InventoryPageViewModel viewModel)
 //       {
	//		if(e is ItemTappedEventArgs itemTapped)
	//		{
	//			viewModel.GetItemDetails((IAddable)itemTapped.Item);
	//			if(sender is ListView listView)
	//			{
	//				listView.SelectedItem = null;
	//			}
	//		}
 //       }
 //   }

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

    protected override async void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
		await _playerService.SavePlayer();
        base.OnNavigatedFrom(args);
    }


}