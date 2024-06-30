using NFCombat2.Models.Contracts;
using NFCombat2.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Programs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NFCombat2.Models.Actions;
using NFCombat2.Services;
using CommunityToolkit.Maui.Views;
using NFCombat2.Views;
using CommunityToolkit.Maui.Alerts;

namespace NFCombat2.ViewModels
{
    public class OptionPickerViewModel : INotifyPropertyChanged
    {

        
        private IFightService _fightService;
        private INameService _nameService;
        
        public OptionPickerViewModel(IFightService fightService, INameService nameService)
        {
            _fightService = fightService;
            _nameService = nameService;
            
            OptionChosenCommand = new Command<IOption>(o => Option(o.Content));
            InfoCommand = new Command<IOption>(o => Info(o.Content));
            BackCommand = new Command(Back);
            BackButtonLabel = _nameService.Label(Common.Enums.LabelType.BackButton);


        }

        private string _backButtonLabel;
        public string BackButtonLabel { get { return _backButtonLabel; }
            set
            {
                if(_backButtonLabel != value)
                {
                    _backButtonLabel = value;
                    OnPropertyChanged(nameof(BackButtonLabel));
                }
            } 
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

        private bool canGoBack = false;
        public bool CanGoBack
        {
            get { return canGoBack; }
            set
            {
                if (canGoBack != value)
                {
                    canGoBack = value;
                    OnPropertyChanged(nameof(CanGoBack));
                }
            }
        }


        public Command OptionChosenCommand { get; set; }
        public Command InfoCommand { get; set; }
        public Command BackCommand { get; set; }

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
        private string menulabel;
        public string MenuLabel { 
            get 
            {
                return menulabel;
            }
            set
            {
                if(menulabel != value)
                {
                    menulabel = value;
                    OnPropertyChanged(nameof(MenuLabel));
                }
            }
        }

        public ITarget TargetingEffect { get; set; }

        public async void Info(object e)
        {
            if (e is IAction action)
            {
                string description = action.Description;
                var toast = new Snackbar() { Text = description, Duration=TimeSpan.FromSeconds(10) };
                await toast.Show();
            }
        }

        public async void CleanUp()
        {
            Options?.Clear();
            MenuLabel = string.Empty;
            ChoosingOption = false;
            CanGoBack = false;

        }

        public async void Option(object option)
        {

            var newOptions = await _fightService.ProcessChoice(option);
            MenuLabel = newOptions.Label;
            IsInfoNeeded = newOptions.IsInfoNeeded;
            CanGoBack = newOptions.CanGoBack;
            Options = new ObservableCollection<IOption>(newOptions.Options);
        }

        public async void Back()
        {
            var previousOptions = _fightService.PreviousOptions;
            IsInfoNeeded = previousOptions.IsInfoNeeded;
            MenuLabel = previousOptions.Label;
            CanGoBack = previousOptions.CanGoBack;
            //Options = new ObservableCollection<IOption>(previousOptions.Options);
            Options.Clear();
            foreach(var  option in previousOptions.Options)
            {
                Options.Add(option);
            }
            
        }



        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
