using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;
using System.Windows.Input;

namespace NFCombat2.Pages;

public partial class ChooseStandardAction : ContentPage
{
	private ICollection<IStandardAction> _standardActions;
	public ChooseStandardAction()
	{
		BindingContext = this;
		InitializeComponent();
	}

	public ChooseStandardAction(ICollection<IStandardAction> standardActions) : base()
	{
		_standardActions = standardActions;
		
		BindingContext = this;
		InitializeComponent();
		
	}

	public ICollection<IStandardAction> StandardActions => _standardActions;

	public async void AffectCombat(object sender, ItemTappedEventArgs e)
	{
		if(e.Item is IStandardAction standardAction)
		{
			standardAction.AffectFight();
		}

		await Navigation.PopAsync();
    }
}