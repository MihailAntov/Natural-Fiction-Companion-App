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

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        
        this.BindingContext = this.Handler.MauiContext.Services.GetRequiredService<FightPageViewModel>();
    }



}