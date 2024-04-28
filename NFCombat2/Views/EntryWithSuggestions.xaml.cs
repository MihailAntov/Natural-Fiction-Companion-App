using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class EntryWithSuggestions : ContentPage
{
	public EntryWithSuggestions(EntryWithSuggestionsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    public async void ChooseItem(object sender, ItemTappedEventArgs e)
    {
        if (BindingContext is EntryWithSuggestionsViewModel viewModel)
        {
            await viewModel.ChooseOption(e.Item);
        }
    }



    public async void EnteredText(object sender, EventArgs e)
    {
        if (BindingContext is EntryWithSuggestionsViewModel viewModel)
        {
            viewModel.EnteredText(sender);
        }
    }

    //public async void OnClosed(object sender, PopupClosedEventArgs e)
    //{
    //    if (BindingContext is EntryWithSuggestionsViewModel viewModel)
    //    {
    //        viewModel.Cancel();
    //    }
    //}

    protected override async void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        if(BindingContext is EntryWithSuggestionsViewModel viewModel)
        {
            viewModel.Cancel();
        }
        base.OnNavigatedFrom(args);
    }




}