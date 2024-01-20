using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class ProgramCastView : Popup
{
	public ProgramCastView(ProgramCastViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    public async void OnClosed(object sender, PopupClosedEventArgs args)
    {
        if (BindingContext is ProgramCastViewModel viewModel)
        {
            viewModel.Cancel();
        }
    }
}