using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Actions;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class WeaponModificationView : Popup
{
	public WeaponModificationView(WeaponModificationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	public async void AttachTo(object sender, EventArgs args)
	{
		if(BindingContext is WeaponModificationViewModel viewModel)
		{
			if(args is ItemTappedEventArgs e)
			{
				if(e.Item is ModificationOption option)
				{
					await viewModel.AttachTo(option.ToBeAttachedTo);
				}

			}
		}
	}

	public async void OnClosed(object sender, PopupClosedEventArgs args)
	{
		if(BindingContext is WeaponModificationViewModel viewModel)
		{
			viewModel.Cancel();
		}
	}
}