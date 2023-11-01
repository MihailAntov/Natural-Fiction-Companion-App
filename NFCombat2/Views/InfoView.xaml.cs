using NFCombat2.ViewModels;

namespace NFCombat2.Views;
public partial class InfoView : ContentView
{
	public InfoView(InfoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	
}