using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class TechniqueChoiceView : Popup
{
	public TechniqueChoiceView(TechniqueChoiceViewModel viewModel)
	{
		InitializeComponent();
		CanBeDismissedByTappingOutsideOfPopup = false;
		BindingContext = viewModel;
	}

    //public async void OnClosed(object sender, PopupClosedEventArgs e)
    //{
    //    if (BindingContext is TechniqueChoiceViewModel viewModel)
    //    {
    //        viewModel.Cancel();
    //    }
    //}
}