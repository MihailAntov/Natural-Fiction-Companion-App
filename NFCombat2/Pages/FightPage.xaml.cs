using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;
using NFCombat2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using NFCombat2.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Pages;

public partial class FightPage : ContentPage
{
	
	
	public FightPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if(this.Handler != null)
        {
            this.BindingContext = this.Handler.MauiContext.Services.GetRequiredService<FightPageViewModel>();
        }
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (this.Handler != null)
        {
            this.BindingContext = this.Handler.MauiContext.Services.GetRequiredService<FightPageViewModel>();
        }
    }







}