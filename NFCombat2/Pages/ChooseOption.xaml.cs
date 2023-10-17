using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;

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

}