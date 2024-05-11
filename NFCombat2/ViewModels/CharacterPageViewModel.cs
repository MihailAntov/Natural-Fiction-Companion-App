using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Pages;
using NFCombat2.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class CharacterPageViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private IPlayerService _playerService;
        private IPopupService _popupService;
        private Player _player;
        private readonly SettingsPageViewModel _settingsPageViewModel;
        
        public Command AddNewProfileCommand { get; set; }
        public CharacterPageViewModel(IPlayerService playerService, IPopupService popupService, INameService nameService, SettingsPageViewModel settingsPageViewModel) : base(nameService)
        {
            _playerService = playerService;
            _popupService = popupService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            AddNewProfileCommand = new Command(async ()=> await AddProfile());
            OpenSettingsCommand = new Command(async () => await OpenSettings());
            Player = _playerService.CurrentPlayer;
            _settingsPageViewModel = settingsPageViewModel;
            
            LoadPlayersAsync();
            
        }

        public List<PlayerClassDisplay> Classes { get
            {
                List<PlayerClassDisplay> classes = (Enum.GetValuesAsUnderlyingType(typeof(PlayerClass)) as PlayerClass[]).Select(pc => new PlayerClassDisplay()
                {
                    Class = pc,
                    Name = _nameService.ClassName(pc)
                }).ToList();
                if(Player != null)
                {
                    SelectedClass = classes.FirstOrDefault(c => c.Class == Player.Class);
                }

                return classes;
            }
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
        private Player _selectedProfile;
        public Player SelectedProfile { get { return _selectedProfile; } set 
            {
                if(_selectedProfile != value) 
                {
                    _selectedProfile = value;
                    OnPropertyChanged(nameof(SelectedProfile));
                }
            }
        }


        private PlayerClassDisplay _selectedClass;
        public PlayerClassDisplay SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                if (_selectedClass != value)
                {
                    _selectedClass = value;
                    OnPropertyChanged(nameof(SelectedClass));
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

        private string _characterPageTitle;
        public string CharacterPageTitle
        {
            get { return _characterPageTitle; }
            set
            {
                if (_characterPageTitle != value)
                {
                    _characterPageTitle = value;
                    OnPropertyChanged(nameof(CharacterPageTitle));
                }
            }
        }

        private string _changeProfilePicker;
        public string ChangeProfilePicker
        {
            get { return _changeProfilePicker; }
            set
            {
                if (_changeProfilePicker != value)
                {
                    _changeProfilePicker = value;
                    OnPropertyChanged(nameof(ChangeProfilePicker));
                }
            }
        }

        private string _playerClassLabel;
        public string PlayerClassLabel
        {
            get { return _playerClassLabel; }
            set
            {
                if (_playerClassLabel != value)
                {
                    _playerClassLabel = value;
                    OnPropertyChanged(nameof(PlayerClassLabel));
                }
            }
        }

        private string _changeClassPicker;
        public string ChangeClassPicker
        {
            get { return _changeClassPicker; }
            set
            {
                if (_changeClassPicker != value)
                {
                    _changeClassPicker = value;
                    OnPropertyChanged(nameof(ChangeClassPicker));
                }
            }
        }

        private string _addNewProfileButton;
        public string AddNewProfileButton
        {
            get { return _addNewProfileButton; }
            set
            {
                if (_addNewProfileButton != value)
                {
                    _addNewProfileButton = value;
                    OnPropertyChanged(nameof(AddNewProfileButton));
                }
            }
        }

        //public ObservableCollection<Player> Profiles {get; set;}
        public IList<Player> Profiles { get; set; } = new List<Player>();
        public Command OpenSettingsCommand { get; set; }
        public async Task AddProfile()
        {
            var player = await _popupService.ShowAddProfilePopup(_playerService);

            if(player == null)
            {
                return;
            }
            await SwitchToProfile(player);

            //OnPropertyChanged(nameof(Profiles));
            LoadPlayersAsync();
            
            
        }

        

        public async void LoadPlayersAsync()
        {
            var players = await _playerService.GetAllPlayers();
            if(Player!= null)
            {
                SelectedProfile = players.FirstOrDefault(p => p.Id == Player.Id);
            }
            Profiles = new ObservableCollection<Player>(players);
            OnPropertyChanged(nameof(Profiles));

        }

        public async void ProcessChoice(object newItem)
        {
            
            if(newItem is Player player)
            {
                await SwitchToProfile(player);
                return;
            }

            if(newItem is PlayerClassDisplay playerClass)
            {
                await ChangeClass(playerClass.Class);
                return;
            }

            
        }
        public async Task SwitchToProfile(Player player)
        {
            await _playerService.SavePlayer();
            await _playerService.SwitchToPlayer(player);
            OnPropertyChanged(nameof(Profiles));
            SelectedProfile = player;
            SelectedClass = Classes.FirstOrDefault(c=> c.Class == player.Class);

        }

        public async Task ChangeClass(PlayerClass playerClass)
        {
            _playerService.CurrentPlayer.Class = playerClass;
            await _playerService.SavePlayer();
        }

        
        public async Task OpenSettings()
        {
            await Shell.Current.Navigation.PushAsync(new SettingsPage(_settingsPageViewModel));
        }

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                if(_playerService.CurrentPlayer != null)
                {
                    Player = _playerService.CurrentPlayer;
                    PlayerClassLabel = _nameService.ClassName(Player.Class);
                    HasChosenHero = true;
                }
                else
                {
                    HasChosenHero = false;
                }
            }
        }

        public override void UpdateLanguageSpecificProperties()
        {
            CharacterPageTitle = _nameService.Label(LabelType.CharacterPageTitle);
            ChangeClassPicker = _nameService.Label(LabelType.ChangeClassPicker);
            ChangeProfilePicker = _nameService.Label(LabelType.ChangeProfilePicker);
            AddNewProfileButton = _nameService.Label(LabelType.AddNewProfileButton);
            if(Player != null)
            {
                PlayerClassLabel = _nameService.ClassName(Player.Class);
            }
            //to update the class name dropdown names
            OnPropertyChanged(nameof(Classes));
            
        }
    }
}
