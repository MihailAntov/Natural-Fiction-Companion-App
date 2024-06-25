using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Pages;
using NFCombat2.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NFCombat2.ViewModels
{
    public class CharacterPageViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private IPlayerService _playerService;
        private IPopupService _popupService;
        private ISettingsService _settingsService;
        private Player _player;
        private readonly SettingsPageViewModel _settingsPageViewModel;
        
        public Command AddNewProfileCommand { get; set; }
        public Command ChangeProfileCommand { get; set; }
        public Command ChangeClassCommand { get; set; }
        public Command ChangeLanguageCommand { get; set; }
        public CharacterPageViewModel(IPlayerService playerService, IPopupService popupService, INameService nameService, SettingsPageViewModel settingsPageViewModel, ISettingsService settingsService) : base(nameService)
        {
            _playerService = playerService;
            _popupService = popupService;
            _settingsService = settingsService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            AddNewProfileCommand = new Command(async ()=> await AddProfile());
            OpenSettingsCommand = new Command(async () => await OpenSettings());
            ChangeProfileCommand = new Command(async () => await ChangeProfile());
            ChangeClassCommand = new Command(async () => await ChangeClass());
            ChangeLanguageCommand = new Command(async () => await ChangeLanguage());
            Player = _playerService.CurrentPlayer;
            _settingsPageViewModel = settingsPageViewModel;
            LanguageIcon = _settingsService.Language == Language.Bulgarian ? "bg" : "en";
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

        private string _languageIcon;
        public string LanguageIcon
        {
            get { return _languageIcon; }
            set
            {
                if(value != _languageIcon)
                {
                    _languageIcon = value;
                    OnPropertyChanged(nameof(LanguageIcon));
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

        private string _characterTab;
        public string CharacterTab { get { return _characterTab; } set
            {
                if(_characterTab != value)
                {
                    _characterTab = value;
                    OnPropertyChanged(nameof(CharacterTab));
                }
            } 
        }

        private string _logTab;
        public string LogTab
        {
            get { return _logTab; }
            set
            {
                if (_logTab != value)
                {
                    _logTab = value;
                    OnPropertyChanged(nameof(LogTab));
                }
            }
        }

        private string _inventoryTab;
        public string InventoryTab
        {
            get { return _inventoryTab; }
            set
            {
                if (_inventoryTab != value)
                {
                    _inventoryTab = value;
                    OnPropertyChanged(nameof(InventoryTab));
                }
            }
        }

        private string _fightTab;
        public string FightTab
        {
            get { return _fightTab; }
            set
            {
                if (_fightTab != value)
                {
                    _fightTab = value;
                    OnPropertyChanged(nameof(FightTab));
                }
            }
        }

        private string _diceTab;
        public string DiceTab
        {
            get { return _diceTab; }
            set
            {
                if (_diceTab != value)
                {
                    _diceTab = value;
                    OnPropertyChanged(nameof(DiceTab));
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

        public async Task ChangeProfile()
        {
            await LoadPlayersAsync();
            TaskCompletionSource<Player> taskCompletionSource = new TaskCompletionSource<Player>();
            var viewModel = new ProfilePickerPopupViewModel(taskCompletionSource, Profiles.Where(p=> p.Id != _player.Id).ToList(), _popupService,_playerService,_nameService, this);
            var view = new ProfilePickerPopupView(viewModel);
            await Shell.Current.Navigation.PushAsync(view);
            var profile = await taskCompletionSource.Task;
            if(profile != null)
            {
                ProcessChoice(profile);
                await Shell.Current.Navigation.PopAsync();
            }
        }

        public async Task ChangeClass()
        {
            TaskCompletionSource<PlayerClassDisplay> taskCompletionSource = new TaskCompletionSource<PlayerClassDisplay>();
            var viewModel = new ClassPickerPopupViewModel(taskCompletionSource, Classes);
            var view = new ClassPickerPopupView(viewModel);
            await Shell.Current.Navigation.PushAsync(view);

            var classDisplay = await taskCompletionSource.Task;
            if (classDisplay != null)
            {
                ProcessChoice(classDisplay);
                await Shell.Current.Navigation.PopAsync();
            }
        }

        

        public async Task LoadPlayersAsync()
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
            CharacterPageTitle = player.Name;

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
                if(_playerService.CurrentPlayer != null && _playerService.CurrentPlayer.Name != null)
                {
                    Player = _playerService.CurrentPlayer;
                    PlayerClassLabel = _nameService.ClassName(Player.Class);
                    CharacterPageTitle = Player.Name;
                    HasChosenHero = true;
                }
                else
                {
                    HasChosenHero = false;
                }
            }
        }

        public async Task ChangeLanguage()
        {
            if (_settingsService.Language == Language.Bulgarian)
            {
                await _settingsService.SetLanguage(Language.English);
                LanguageIcon = "en";
                return;
            }

            await _settingsService.SetLanguage(Language.Bulgarian);
            LanguageIcon = "bg";
        }

        public override void UpdateLanguageSpecificProperties()
        {
            //CharacterPageTitle = _nameService.Label(LabelType.CharacterPageTitle);
            ChangeClassPicker = _nameService.Label(LabelType.ChangeClassPicker);
            ChangeProfilePicker = _nameService.Label(LabelType.ChangeProfilePicker);
            AddNewProfileButton = _nameService.Label(LabelType.AddNewProfileButton);
            LogTab = _nameService.Label(LabelType.LogTab);
            CharacterTab = _nameService.Label(LabelType.CharacterTab);
            DiceTab = _nameService.Label(LabelType.DiceTab);
            InventoryTab = _nameService.Label(LabelType.InventoryTab);
            FightTab = _nameService.Label(LabelType.FightTab);
            if (Player != null)
            {
                PlayerClassLabel = _nameService.ClassName(Player.Class);
            }
            //to update the class name dropdown names
            OnPropertyChanged(nameof(Classes));
            
            
        }
    }
}
