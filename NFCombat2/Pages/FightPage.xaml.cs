using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Contracts;
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

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }

    public async void HideKeyboard(object sender, EventArgs e)
    {
        EpisodeEntry.IsEnabled = false;
        EpisodeEntry.IsEnabled = true;
    }







}