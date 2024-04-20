using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    public async void ChosenLanguage(object sender, CheckedChangedEventArgs e)
    {
        if (BindingContext is SettingsPageViewModel viewModel)
        {
            if (sender is RadioButton button)
            {
                viewModel.ChooseLanguage((string)button.Value, button.IsChecked);
            }
        }
    }
}