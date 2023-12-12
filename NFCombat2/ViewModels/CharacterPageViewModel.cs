using CommunityToolkit.Maui.Views;
using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class CharacterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IPlayerService _playerService;
        private IPopupService _popupService;
        private Player _player;
        
        public Command AddNewProfileCommand { get; set; }
        public CharacterPageViewModel(IPlayerService playerService, IPopupService popupService)
        {
            _playerService = playerService;
            _popupService = popupService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            AddNewProfileCommand = new Command(async ()=> await AddProfile());
            Player = _playerService.CurrentPlayer;
            SelectedItem = _playerService.CurrentPlayer;
            LoadPlayersAsync();
            
        }

        private double _hpValue;

        public double HpValue
        {
            get { return _hpValue; }
            set
            {

                if (_hpValue != Math.Round(value, 0))
                {
                    _hpValue = Math.Round(value, 0);
                    OnPropertyChanged(nameof(HpValue));
                }

            }
        }
        private Player _selectedItem { get; set; }
        public Player SelectedItem { get { return _selectedItem; } set 
            {
                if(_selectedItem != value) 
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private bool _hasChosenHero = false;
        public bool HasChosenHero
        {
            get { return _hasChosenHero; }
            set
            {
                if (_hasChosenHero != value)
                {
                    _hasChosenHero = value;
                    OnPropertyChanged(nameof(HasChosenHero));
                }
            }
        }

        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                if(_player != value) 
                {
                    _player = value;
                    OnPropertyChanged(nameof(Player));                    
                    OnPropertyChanged(nameof(Player.Health));                    
                }
            }
        }
        
        

        public ObservableCollection<Player> Profiles {get; set;}

        public async Task AddProfile()
        {
            var player = await _popupService.ShowAddProfilePopup(_playerService);

            if(player == null)
            {
                return;
            }
            await SwitchToProfile(player);

            OnPropertyChanged(nameof(Profiles));
            
            
        }

        

        public async void LoadPlayersAsync()
        {
            var players = await _playerService.GetAllPlayers();
            Profiles = new ObservableCollection<Player>(players);
            OnPropertyChanged(nameof(Profiles));

        }

        public async void ProcessChoice(object newItem)
        {
            
            if(newItem is Player player)
            {
                await SwitchToProfile(player);
            }

            
        }
        public async Task SwitchToProfile(Player player)
        {
            await _playerService.SavePlayer();
            await _playerService.SwitchToPlayer(player);
            OnPropertyChanged(nameof(Profiles));
            SelectedItem = player;
            
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                if(_playerService.CurrentPlayer != null)
                {
                    Player = _playerService.CurrentPlayer;
                    HasChosenHero = true;
                }
                else
                {
                    HasChosenHero = false;
                }
            }
        }

    }
}
