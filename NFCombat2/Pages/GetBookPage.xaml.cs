using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class GetBookPage : ContentPage
{
    private bool _navigatedFrom = false;
	public GetBookPage(GetBookPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}



}