using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class ProfilePickerPopupView : ContentPage
{
	public ProfilePickerPopupView(ProfilePickerPopupViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}

    protected override async void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        if (BindingContext is ProfilePickerPopupViewModel viewModel)
        {
            viewModel.Cancel();
        }
        base.OnNavigatedFrom(args);
    }
}