

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
        private readonly IPopupService _popupService;
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
        public AddingProfileViewModel(IPlayerService playerService,IPopupService popupService, TaskCompletionSource<Player> taskCompletionSource, INameService nameService) : base (nameService)
        {
            RegisterCommand = new Command<Player>(async (player) => await RegisterPlayer(player));
            _playerService = playerService;
            _popupService = popupService;
            _taskCompletionSource = taskCompletionSource;
            PlayerClasses = playerService.GetClassOptions();
        }

        public List<PlayerClass> PlayerClasses { get; set; }
        public async Task RegisterPlayer(Player player)
        {
            
            await _playerService.SavePlayer();
            if (string.IsNullOrWhiteSpace(player.Name))
            {
                
                _popupService.ShowToast("Please insert player name.");
                return;
            }
            var result = await _playerService.RegisterPlayer(player);
            _popupService.ShowToast($"Successfully Added {player.Name}");
            
            _taskCompletionSource.SetResult(result);


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
