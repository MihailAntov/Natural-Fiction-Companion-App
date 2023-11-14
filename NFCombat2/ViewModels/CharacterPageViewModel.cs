using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class CharacterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IPlayerService _playerService;
        private Player _player;
        public Command RegisterCommand { get;  set; }
        public CharacterPageViewModel(IPlayerService playerService)
        {
            _playerService = playerService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            RegisterCommand = new Command<string>(async (name) => await RegisterProfile(name));
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

        public async void ChangedClass()
        {
            //string name = (await _profileService.GetAll()).FirstOrDefault()?.Name;
        }



        public async Task<bool> RegisterProfile(string name)
        {
            
            return await _playerService.Save(name);
            //await DisplayAlert("Successfully Added", $"{name}", "Okay");
        }

        public IList<Player> GetAllProfiles()
        {
            var profiles = _playerService.GetAll();
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
