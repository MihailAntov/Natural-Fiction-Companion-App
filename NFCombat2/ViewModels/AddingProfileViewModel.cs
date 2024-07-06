

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using System.Xml.Linq;

namespace NFCombat2.ViewModels
{
    public class AddingProfileViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; set; }
        private readonly IPlayerService _playerService;
        private readonly IMyPopupService _popupService;
        private TaskCompletionSource<Player> _taskCompletionSource;
        private string _selectClassLabel;
        public string SelectClassLabel
        {
            get { return _selectClassLabel; }
            set
            {
                if(_selectClassLabel != value)
                {
                    _selectClassLabel = value;
                    OnPropertyChanged(nameof(SelectClassLabel));
                }
            }
        }
        private string _playerNameLabel;
        public string PlayerNameLabel
        {
            get { return _playerNameLabel; }
            set
            {
                if (_playerNameLabel != value)
                {
                    _playerNameLabel = value;
                    OnPropertyChanged(nameof(PlayerNameLabel));
                }
            }
        }

        
        private string _playerNameHintLabel;
        public string PlayerNameHintLabel
        {
            get { return _playerNameHintLabel; }
            set
            {
                if (_playerNameHintLabel != value)
                {
                    _playerNameHintLabel = value;
                    OnPropertyChanged(nameof(PlayerNameHintLabel));
                }
            }
        }
        private string _addPlayerButtonlabel;
        public string AddPlayerButtonLabel
        {
            get { return _addPlayerButtonlabel; }
            set
            {
                if (_addPlayerButtonlabel != value)
                {
                    _addPlayerButtonlabel = value;
                    OnPropertyChanged(nameof(AddPlayerButtonLabel));
                }
            }
        }
        public AddingProfileViewModel(IPlayerService playerService, IMyPopupService popupService, TaskCompletionSource<Player> taskCompletionSource, INameService nameService) : base (nameService)
        {
            RegisterCommand = new Command<Player>(async (player) => await RegisterPlayer(player));
            _playerService = playerService;
            _popupService = popupService;
            _taskCompletionSource = taskCompletionSource;
            PlayerClasses = playerService.GetClassOptions();
        }

        public List<PlayerClassDisplay> PlayerClasses { get; set; }
        public async Task RegisterPlayer(Player player)
        {
            
          await _playerService.SavePlayer();
            if (string.IsNullOrWhiteSpace(player.Name))
            {
                string emptyPlayerNameToast = _nameService.Label(LabelType.NoPlayerName);
                //_popupService.ShowToast("Please insert player name.");
                _popupService.ShowToast(emptyPlayerNameToast);
                return;
            }
            var result = await _playerService.RegisterPlayer(player);
            string addPlayerSuccess = String.Format(_nameService.Label(LabelType.AddedPlayer),player.Name);
            //_popupService.ShowToast($"Successfully Added {player.Name}");
            _popupService.ShowToast(addPlayerSuccess);
            
            _taskCompletionSource.SetResult(result);
            await Shell.Current.Navigation.PopAsync();

            //todo add toast
        }

        //public async Task ChangedClass()
        //{

        //}

        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(null);
            //_taskCompletionSource.SetResult(null);
        }

        public override void UpdateLanguageSpecificProperties()
        {
            AddPlayerButtonLabel = _nameService.Label(LabelType.AddPlayerButton);
            SelectClassLabel = _nameService.Label(LabelType.SelectClass);
            PlayerNameLabel = _nameService.Label(LabelType.PlayerName);
            PlayerNameHintLabel = _nameService.Label(LabelType.PlayerNameHint);
        }
    }
}
