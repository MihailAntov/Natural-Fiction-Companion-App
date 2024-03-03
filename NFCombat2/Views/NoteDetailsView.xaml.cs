using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class NoteDetailsView : ContentView
{
	public NoteDetailsView(NoteDetailsViewModel viewModel)
	{

		InitializeComponent();
		BindingContext = viewModel;
	}
}