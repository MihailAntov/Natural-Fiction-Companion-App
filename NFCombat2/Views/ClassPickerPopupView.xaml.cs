using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class ClassPickerPopupView : ContentPage
{
	public ClassPickerPopupView(ClassPickerPopupViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}

    protected override async void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        if (BindingContext is ClassPickerPopupViewModel viewModel)
        {
            viewModel.Cancel();
        }
        base.OnNavigatedFrom(args);
    }
}