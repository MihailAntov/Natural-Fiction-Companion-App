

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using System.Xml.Linq;

namespace NFCombat2.ViewModels
{
    public class AddingProfileViewModel
    {
        public Command RegisterCommand { get; set; }
        private readonly IPlayerService _playerService;
        private readonly IPopupService _popupService;
        private TaskCompletionSource<Player> _taskCompletionSource;

        public AddingProfileViewModel(IPlayerService playerService,IPopupService popupService, TaskCompletionSource<Player> taskCompletionSource)
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

        public async Task ChangedClass()
        {

        }

        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(null);
            //_taskCompletionSource.SetResult(null);
        }
    }
}
