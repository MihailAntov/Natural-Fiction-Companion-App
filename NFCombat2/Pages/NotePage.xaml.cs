using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class NotePage : ContentPage
{
	public NotePage(NotePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}