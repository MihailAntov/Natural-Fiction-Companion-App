using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class PartsBagView : ContentView
{
	public PartsBagView()
	{
		InitializeComponent();
		
	}

    protected override void OnHandlerChanged()
    {
        this.BindingContext = this.Handler.MauiContext.Services.GetRequiredService<PartsBagViewModel>();
        base.OnHandlerChanged();
    }
}