using NFCombat2.Models.Contracts;
using NFCombat2.Services.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NFCombat2.ViewModels
{
    public class OptionPickerViewModel : INotifyPropertyChanged
    {
      
        private IOptionsService _optionsService;
        private IFightService _fightService;

        public OptionPickerViewModel(IOptionsService optionsService, IFightService fightService)
        {
            _optionsService = optionsService;
            _fightService = fightService;

            //if (Categories == null)
            //{
            //    Categories = new ObservableCollection<string>(_optionsService.GetCategories(_fightService.GetFight()));
            //}
            OptionChosen = new Command(Option);
        }
        private bool choosingCategory = true;
        public bool ChoosingCategory
        {
            get { return choosingCategory; }
            set
            {
                if (choosingCategory != value)
                {
                    choosingCategory = value;
                    OnPropertyChanged(nameof(ChoosingCategory));
                }
            }
        }

        public Command OptionChosen { get; set; }

        public ObservableCollection<IAction> Actions {get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
       

        private ObservableCollection<string> categories;
        public ObservableCollection<string> Categories { get { return categories; }
            set 
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        private ObservableCollection<IAction> options;
        public ObservableCollection<IAction> Options
        {
            get { return options; }
            set
            {
                options = value;
                OnPropertyChanged(nameof(Options)); 
            }
        }

        public async void Option(object e)
        {

            
            var fight = _fightService.GetFight();
            if (e is string category)
            {
                ICollection<IAction> options = new List<IAction>();
                switch (category)
                {
                    case "Programs":
                        options = _optionsService.GetPrograms(fight);
                        break;
                    case "Shoot":
                    case "Attack":
                        break;
                    case "Items":
                        options = _optionsService.GetItems(fight);
                        break;
                    case "Move":
                        break;
                }
                Options = new ObservableCollection<IAction>(options);
                ChoosingCategory = false;

            }


            if (e is IAffectCombat combatEffect)
            {
                _fightService.SelectAction(combatEffect);

            }

            _fightService.ResolveEffects();

            if (fight.HasBonusAction)
            {
                Categories = new ObservableCollection<String>(_optionsService.GetBonusCategories(fight));
                ChoosingCategory = true;
            }




        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
