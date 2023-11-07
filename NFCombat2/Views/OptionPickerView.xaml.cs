using NFCombat2.Models.Contracts;
using NFCombat2.Contracts;
using NFCombat2.ViewModels;

namespace NFCombat2.Views;

public partial class OptionPickerView : ContentView
{
    

    public OptionPickerView()
    {
        InitializeComponent();
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        this.BindingContext = this.Handler.MauiContext.Services.GetRequiredService<OptionPickerViewModel>();
    }

   




}


