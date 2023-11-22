using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class LogPage : ContentPage
{
	public LogPage(LogPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}