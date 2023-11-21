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
        public int SelectedIndex { get; }
        public CharacterPageViewModel(IPlayerService playerService, IPopupService popupService)
        {
            _playerService = playerService;
            _popupService = popupService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            AddNewProfileCommand = new Command(async ()=> await AddProfile());
            Player = _playerService.CurrentPlayer;
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
                    OnPropertyChanged(nameof(_playerService.CurrentPlayer));
                }
            }
        }
        
        

        public ObservableCollection<Player> Profiles => new ObservableCollection<Player>(GetAllProfiles());
        public async Task CreateNewProfile(Popup popup)
        {
            
        }

        public async Task AddProfile()
        {
            await _popupService.ShowAddProfilePopup();
            OnPropertyChanged(nameof(Profiles));
        }

        

        public IList<Player> GetAllProfiles()
        {
            var profiles = Task<Player>.Run(()=> 
                 _playerService.GetAll()).Result;
            return profiles;
        }

        public async void ProcessChoice(object sender)
        {
            if(sender is Picker picker)
            {
                await SwitchToProfile((Player)picker.SelectedItem);
            }

            
        }
        public async Task SwitchToProfile(Player player)
        {
            await _playerService.SwitchActiveProfile(player);
            
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
            }
        }

    }
}
