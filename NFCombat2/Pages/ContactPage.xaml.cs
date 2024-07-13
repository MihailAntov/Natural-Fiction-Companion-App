using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class ContactPage : ContentPage
{
	public ContactPage(ContactPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}

}