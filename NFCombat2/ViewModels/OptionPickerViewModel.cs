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
using CommunityToolkit.Maui.Alerts;

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
                var toast = new Snackbar() { Text = description, Duration=TimeSpan.FromSeconds(3) };
                await toast.Show();
            }
        }

        public async void CleanUp()
        {
            Options?.Clear();
            ChoosingOption = false;
        }

        public async void Option(object option)
        {
            var newOptions = _fightService.ProcessChoice(option);
            IsInfoNeeded = newOptions.IsInfoNeeded;
            Options = new ObservableCollection<IOption>(newOptions.Options);
        }



        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
