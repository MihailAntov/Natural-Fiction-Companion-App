using NFCombat2.Models.Fights;
using NFCombat2.Contracts;
using System.Collections.ObjectModel;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NFCombat2.Models.Player;
using NFCombat2.Common.Enums;
using NFCombat2.Services;

namespace NFCombat2.ViewModels
{
    public class FightPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Fight _fight;

        public Fight Fight { get { return _fight; } set 
            {
                if(_fight!= value)
                {
                    _fight = value;
                    OnPropertyChanged(nameof(Fight));
                }
            }
        }
        private IFightService _fightService;
        private IOptionsService _optionsService;
        private ILogService _logService;
        private IMyPopupService _popupService;


        public FightPageViewModel(IFightService fightService,
            IOptionsService optionsService,
            ILogService logService,
            IMyPopupService popupSerivce,
            INameService nameService,
            OptionPickerViewModel opctionPickerViewModel, ISettingsService settingsService) : base(nameService, settingsService)
        {
            _fightService = fightService;
            _fightService.PropertyChanged += OnFightServiceEnemiesPropertyChanged;
            _optionsService = optionsService;
            _logService = logService;
            _popupService = popupSerivce;
            _nameService = nameService;
            _fightService.PropertyChanged += OnAcceptedPropertyChanged;

            OptionPickerViewModel = opctionPickerViewModel;
            GetEpisodeCommand = new Command(GetEpisode);
            CancelCombatCommand = new Command(CancelCombat);
        }

        public Command GetEpisodeCommand { get; }
        public Command CancelCombatCommand { get; }
        public ListView MessageBoard { get; set; }
        
        public string EpisodeNumber { get; set; }

        private bool notInCombat = true;
        public bool NotInCombat
        {
            get { return notInCombat; }
            set
            {
                if(notInCombat != value)
                {
                    notInCombat = value;
                    OnPropertyChanged(nameof(NotInCombat));
                }
            }
        }

        private string _fightPageTitle;
        public string FightPageTitle
        {
            get { return _fightPageTitle; }
            set
            {
                if (_fightPageTitle != value)
                {
                    _fightPageTitle = value;
                    OnPropertyChanged(nameof(FightPageTitle));
                }
            }
        }

        private string _findEpisodeButton;
        public string FindEpisodeButton
        {
            get { return _findEpisodeButton; }
            set
            {
                if (_findEpisodeButton != value)
                {
                    _findEpisodeButton = value;
                    OnPropertyChanged(nameof(FindEpisodeButton));
                }
            }
        }

        private string _episodeEntryHint;
        public string EpisodeEntryHint
        {
            get { return _episodeEntryHint; }
            set
            {
                if (_episodeEntryHint != value)
                {
                    _episodeEntryHint = value;
                    OnPropertyChanged(nameof(EpisodeEntryHint));
                }
            }
        }
        public ObservableCollection<Enemy> Enemies { get; set; } = new ObservableCollection<Enemy>();
        public ObservableCollection<string> Messages => _logService.Messages;
        private Player player;
        public Player Player { get { return player; } set 
            {
                if(player != value)
                {
                    player = value;
                    OnPropertyChanged(nameof(Player));
                }
            } 
        }
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<IAction> Options { get; set; } = new ObservableCollection<IAction>();
        public OptionPickerViewModel OptionPickerViewModel { get; set; } 

        
        

        public async void GetEpisode()
        {
            int.TryParse(EpisodeNumber, out int episode);
            
            Fight = await _fightService.GetFightByEpisodeNumber(episode);
            if(Fight == null)
            {
                string message = _nameService.Label(LabelType.InvalidEpisodeNumber);
                _popupService.ShowToast(message);
                return;
            }
            Player = Fight.Player;
            
            

            Enemies.Clear();
            foreach (var enemy in Fight.Enemies)
            {
                Enemies.Add(enemy);
            }
            IOptionList initialOptionList;
            if (Fight.HasFirstStrike)
            {
                initialOptionList = _optionsService.GetFirstStrikeActions(Fight);
            }
            else
            {
                Fight.TurnPhase++;
                initialOptionList = _optionsService.GetMoveActions(Fight);
            }
            //var initialOptionList = Fight.HasFirstStrike ? _optionsService.GetFirstStrikeActions(Fight) : _optionsService.GetMoveActions(Fight);
            _fightService.PreviousOptions = initialOptionList;
            OptionPickerViewModel.Options = new ObservableCollection<IOption>(initialOptionList.Options);
            OptionPickerViewModel.MenuLabel = initialOptionList.Label;
            OptionPickerViewModel.ChoosingOption = true;
            
            NotInCombat = false;

        }

        public async void CancelCombat()
        {
            NotInCombat = true;
            _fightService.RejectFightResults();
            CombatCleanup();
        }

        private async void CombatCleanup()
        {
            OnPropertyChanged(nameof(Fight.Player));
            Fight = null;
            Enemies.Clear();
            OptionPickerViewModel.CleanUp();
            _logService.Messages.Clear();
            OptionPickerViewModel.IsInfoNeeded = false;
        }


        private void OnAcceptedPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_fightService.Accepted))
            {
                NotInCombat = true;
                CombatCleanup(); 
            }
        }

        private void OnFightServiceEnemiesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
         if(e.PropertyName == nameof(_fight.Enemies))
            {
                Enemies.Clear();
                foreach (var enemy in Fight.Enemies)
                {
                    Enemies.Add(enemy);
                }
            }   
        }

        public override void UpdateLanguageSpecificProperties()
        {
            FightPageTitle = _nameService.Label(LabelType.FightPageTitle);
            FindEpisodeButton = _nameService.Label(LabelType.FindEpisodeButton);
            EpisodeEntryHint = _nameService.Label(LabelType.EpisodeEntryHint);
        }
    }
}
