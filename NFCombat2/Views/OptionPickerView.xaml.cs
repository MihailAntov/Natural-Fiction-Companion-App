using NFCombat2.Models.Contracts;
using NFCombat2.Services.Contracts;
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

    //public async void OptionChosen(object sender, ItemTappedEventArgs e)
    //{
    //    if (this.BindingContext is OptionPickerViewModel viewModel)
    //    {
    //        if (e.Item is string category)
    //        {
    //            viewModel.Option(category);
    //        }

    //    }
    //}




}


