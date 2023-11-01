using NFCombat2.Models.Contracts;
using NFCombat2.Services.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Programs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NFCombat2.Models.Actions;
using NFCombat2.Services;
using CommunityToolkit.Maui.Views;
using NFCombat2.Popups;
using NFCombat2.Views;

namespace NFCombat2.ViewModels
{
    public class OptionPickerViewModel : INotifyPropertyChanged
    {

        private IOptionsService _optionsService;
        private IFightService _fightService;
        private ILogService _logService;
        private IPopupService _popupService;
        public OptionPickerViewModel(IOptionsService optionsService, IFightService fightService, ILogService logService, IPopupService popupService)
        {
            _optionsService = optionsService;
            _fightService = fightService;
            _logService = logService;
            _popupService = popupService;
            OptionChosenCommand = new Command<IOption>(o => Option(o.Content));
            InfoCommand = new Command<IOption>(o => Info(o.Content));


        }


        private bool choosingOption = true;
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

        private bool isInfoNeeded = false;
        public bool IsInfoNeeded
        {
            get { return isInfoNeeded; }
            set
            {
                if (isInfoNeeded != value)
                {
                    isInfoNeeded = value;
                    OnPropertyChanged(nameof(IsInfoNeeded));
                }
            }
        }


        public Command OptionChosenCommand { get; set; }
        public Command InfoCommand { get; set; }

        public ObservableCollection<IAction> Actions { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;



        private ObservableCollection<IOption> options;
        public ObservableCollection<IOption> Options
        {
            get { return options; }
            set
            {
                options = value;
                OnPropertyChanged(nameof(Options));
            }
        }

        public ITarget TargetingEffect { get; set; }

        public async void Info(object e)
        {
            if (e is IAction action)
            {
                string description = action.Description;
                var viewModel = new InfoViewModel(description);
                var info = new InfoPopUp()
                {
                    Content = new InfoView(viewModel)
                };
                _popupService.ShowPopup(info);
            }




        }

        public async void CleanUp()
        {
            Options?.Clear();
            ChoosingOption = false;


        }

        private async void CompleteTurn()
        {
            _fightService.ResolveEffects();
            var categories = _optionsService.GetMoveActions(_fightService.GetFight());
            Options = new ObservableCollection<IOption>(categories);
            IsInfoNeeded = false;
        }


        public async void Option(object e)
        {
            var fight = _fightService.GetFight();



            if (e is string category)
            {
                ICollection<IOption> options = new List<IOption>();
                switch (category)
                {
                    case "Programs":
                        IsInfoNeeded = true;
                        options = _optionsService.GetPrograms(fight);
                        break;
                    case "Shoot":
                    case "Attack":
                        break;
                    case "Items":
                        options = _optionsService.GetItems(fight);
                        IsInfoNeeded = true;
                        break;
                    case "Move":
                        break;
                }
                Options = new ObservableCollection<IOption>(options);
                return;

            }

            if (e is ITarget targetingEffect && !targetingEffect.AreaOfEffect)
            {

                TargetingEffect = targetingEffect;
                var targets = _optionsService.GetTargets(fight, targetingEffect.MinRange, targetingEffect.MaxRange);
                Options = new ObservableCollection<IOption>(targets);
                return;


            }

            if (e is Enemy target)
            {
                TargetingEffect.Targets.Add(target);
                var effect = (ICombatAction)TargetingEffect;
                _fightService.AddEffect((ICombatAction)TargetingEffect);
                _logService.Log(effect.MessageType, effect.MessageArgs);
                CompleteTurn();

            }


            if (e is ICombatAction combatEffect)
            {
                _fightService.AddEffect(combatEffect);
                CompleteTurn();

            }

            _fightService.ResolveEffects();


            if (fight.HasBonusAction)
            {
                Options = new ObservableCollection<IOption>(_optionsService.GetBonusActions(fight));
                fight.HasBonusAction = false;
                return;
            }



        }



        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
