using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class EntryWithSuggestions : Popup
{
	public EntryWithSuggestions(EntryWithSuggestionsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        CanBeDismissedByTappingOutsideOfPopup = false;
	}

    public async void ChooseItem(object sender, ItemTappedEventArgs e)
    {
        if (BindingContext is EntryWithSuggestionsViewModel viewModel)
        {
            viewModel.ChooseOption(e.Item);
        }
    }

    public async void EnteredText(object sender, EventArgs e)
    {
        if (BindingContext is EntryWithSuggestionsViewModel viewModel)
        {
            viewModel.EnteredText(sender);
        }
    }

    
}