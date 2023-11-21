using CommunityToolkit.Maui.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class AddingProfileView : Popup
{
	public AddingProfileView(AddingProfileViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
       
	}

    public async void ChangedClass(object sender, EventArgs e)
    {
        if (BindingContext is AddingProfileViewModel viewModel)
        {
            await viewModel.ChangedClass();
        }
    }
}