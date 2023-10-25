using NFCombat2.Models.Contracts;
using NFCombat2.Services.Contracts;

namespace NFCombat2.Views;

public partial class OptionPickerView : ContentView
{
    private ICollection<IAction> _actions;
    private ICollection<string> _categories;
    private IOptionsService _optionsService;
    private IFightService _fightService;

    public OptionPickerView()
    {
        BindingContext = this;
        _fightService = this.Handler.MauiContext.Services.GetRequiredService<IFightService>();
        _optionsService = this.Handler.MauiContext.Services.GetRequiredService<IOptionsService>();
        InitializeComponent();
        
    }

	public OptionPickerView(ICollection<IAction> actions) : base()
	{
		BindingContext = this;
		_actions = actions;
        InitializeComponent();

	}

    public OptionPickerView(ICollection<string> categories) : base()
    {
        BindingContext = this;
        _categories = categories;
        InitializeComponent();
    }

    

    public ICollection<IAction> Actions => _actions;
    public ICollection<string> Categories => _categories;

    public async void OptionClicked(object sender, ItemTappedEventArgs e)
    {
        
        
        if(e.Item is string category)
        {
            ICollection<IAction> options = new List<IAction>();
            var fight = _fightService.GetFight();
            switch(category)
            {
                case "Programs":
                    options = _optionsService.GetPrograms(fight) as ICollection<IAction>;
                    break;
                case "Shoot":
                case "Attack":
                    break;
                case "Item":
                    options = _optionsService.GetItems(fight) as ICollection<IAction>;
                    break;
                case "Move in":
                    break;
            }


        }
        
        if (e.Item is IStandardAction standardAction)
        {
            standardAction.AffectFight(_fightService.GetFight());
        }

        await Navigation.PopAsync();
    }


}