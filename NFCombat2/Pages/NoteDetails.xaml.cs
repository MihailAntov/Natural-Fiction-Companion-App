using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class NoteDetails : ContentPage
{
	public NoteDetails(NoteDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}