using NFCombat2.Models.Contracts;
using NFCombat2.Services.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Programs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NFCombat2.Models.Actions;


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
            OptionChosenCommand = new Command(Option);
            InfoCommand = new Command(Info);

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

        private bool choosingOption = false;
        public bool ChoosingOption
        {
            get { return choosingOption; }
            set
            {
                if (choosingOption != value)
                {
                    choosingOption = value;
                    OnPropertyChanged(nameof(ChoosingOption));
                }
            }
        }


        private bool choosingTarget = false;
        public bool ChoosingTarget
        {
            get { return choosingTarget; }
            set
            {
                if(choosingTarget != value)
                {
                    choosingTarget = value; 
                    OnPropertyChanged(nameof(ChoosingTarget));
                }
            }
        }

        public Command OptionChosenCommand { get; set; }
        public Command InfoCommand { get; set; }

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
        private ObservableCollection<Enemy> targets;
        public ObservableCollection<Enemy> Targets
        {
            get
            {
                return targets;
            }
            set
            {
                if (targets != value)
                {
                    targets = value;
                    OnPropertyChanged(nameof(Targets));
                }
            }
        }
        public ITarget TargetingEffect { get; set; }

        public async void Info(object e)
        {
            //TODO invoke popup service to display info on program
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
                ChoosingOption = true;
                return;

            }

            if (e is ITarget targetingEffect && !targetingEffect.AreaOfEffect)
            {

                TargetingEffect = targetingEffect;
                var targets = _optionsService.GetTargets(fight, targetingEffect.MinRange, targetingEffect.MaxRange);
                Targets = new ObservableCollection<Enemy>(targets);
                ChoosingOption = false;
                ChoosingTarget = true;
                return;


            }

            if (e is Enemy target)
            {
                TargetingEffect.Targets.Add(target);
                _fightService.AddEffect((IAffectCombat)TargetingEffect);
                ChoosingTarget = false;
                ChoosingCategory = true;

            }


            if (e is IAffectCombat combatEffect)
            {
                _fightService.AddEffect(combatEffect);

            }

            _fightService.ResolveEffects();

            if (fight.HasBonusAction)
            {
                Categories = new ObservableCollection<String>(_optionsService.GetBonusCategories(fight));
                ChoosingCategory = true;
                fight.HasBonusAction = false;
            }




        }

        

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
