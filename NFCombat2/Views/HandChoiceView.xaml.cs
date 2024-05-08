using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class HandChoiceView : Popup
{
	public HandChoiceView(HandChoiceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    public async void OnClosed(object sender, PopupClosedEventArgs args)
    {
        if (BindingContext is HandChoiceViewModel viewModel)
        {
            viewModel.Cancel();
        }
    }
}