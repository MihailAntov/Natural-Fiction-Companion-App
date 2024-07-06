using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Views;
using System.Collections.ObjectModel;

namespace NFCombat2.ViewModels
{
    public class ProfilePickerPopupViewModel : BaseViewModel
    {
        private TaskCompletionSource<Player> _taskCompletionSource;
        private CharacterPageViewModel _parent;
        private IMyPopupService _popupService;
        private IPlayerService _playerService;
        public ObservableCollection<Player> Profiles { get; set; }
        public Command ChooseCommand { get; set; }
        public Command AddNewProfileCommand { get; set; }

        public Command DeleteProfileCommand { get; set; }

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
        public ProfilePickerPopupViewModel(
            TaskCompletionSource<Player> taskCompletionSource,
            IList<Player> profiles,
            IMyPopupService popupService,
            IPlayerService playerService,
            INameService nameService,
            CharacterPageViewModel parent
            ) : base(nameService)
        {
            _taskCompletionSource = taskCompletionSource;
            Profiles = new ObservableCollection<Player>(profiles);
            ChooseCommand = new Command<Player>(Choose);
            AddNewProfileCommand = new Command(async () => await AddProfile());
            DeleteProfileCommand = new Command<Player>(DeleteProfile);
            _popupService = popupService;
            _playerService = playerService;
            _parent  = parent;
        }

        public void Choose(Player player)
        {
            _taskCompletionSource.TrySetResult(player);
        }
        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(null);
        }

        public async void DeleteProfile(Player player)
        {
            string message = _nameService.Label(Common.Enums.LabelType.AreYouSure);
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var vm = new ConfirmationPopupViewModel(message,taskCompletionSource,_nameService);
            var popup = new ConfirmationPopupView(vm);
            _popupService.ShowPopup(popup);

            bool confirmed = await taskCompletionSource.Task;
            await popup.CloseAsync();
            if (confirmed)
            {
                _playerService.DeletePlayer(player);
                Profiles.Remove(player);
            }
            
            
        }
        public async Task AddProfile()
        {
            var player = await _popupService.ShowAddProfilePopup(_playerService);

            if (player == null)
            {
                return;
            }
            await _parent.SwitchToProfile(player);

            //OnPropertyChanged(nameof(Profiles));
            _parent.LoadPlayersAsync();


        }

        public override void UpdateLanguageSpecificProperties()
        {
            AddNewProfileButton = _nameService.Label(Common.Enums.LabelType.AddNewProfileButton);
        }
    }
}
