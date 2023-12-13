using NFCombat2.Models.Fights;
using NFCombat2.Contracts;
using System.Collections.ObjectModel;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NFCombat2.Models.Player;
using NFCombat2.Common.Enums;

namespace NFCombat2.ViewModels
{
    public class FightPageViewModel : INotifyPropertyChanged
    {

        private Fight fight;
        private IFightService _fightService;
        private IOptionsService _optionsService;
        private ILogService _logService;

        public event PropertyChangedEventHandler PropertyChanged;

        public FightPageViewModel(IFightService fightService,
            IOptionsService optionsService,
            ILogService logService,
            OptionPickerViewModel opctionPickerViewModel)
        {
            _fightService = fightService;
            _optionsService = optionsService;
            _logService = logService;
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
            
            fight = await _fightService.GetFightByEpisodeNumber(episode);
            Player = fight.Player;
            
            

            Enemies.Clear();
            foreach (var enemy in fight.Enemies)
            {
                Enemies.Add(enemy);
            }
            var initialOptionList = _optionsService.GetMoveActions(fight);
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
            OnPropertyChanged(nameof(fight.Player));
            fight = null;
            Enemies.Clear();
            OptionPickerViewModel.CleanUp();
            _logService.Messages.Clear();
            OptionPickerViewModel.IsInfoNeeded = false;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnAcceptedPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_fightService.Accepted))
            {
                NotInCombat = true;
                CombatCleanup(); 
            }
        }

        
    }
}
