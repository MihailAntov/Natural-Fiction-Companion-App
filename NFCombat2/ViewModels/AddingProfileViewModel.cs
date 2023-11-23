

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
        private TaskCompletionSource<Player> _taskCompletionSource;

        public AddingProfileViewModel(IPlayerService playerService, TaskCompletionSource<Player> taskCompletionSource)
        {
            RegisterCommand = new Command<Player>(async (player) => await RegisterProfile(player));
            _playerService = playerService;
            _taskCompletionSource = taskCompletionSource;
            PlayerClasses = playerService.GetClassOptions();
        }

        public List<PlayerClass> PlayerClasses { get; set; }
        public async Task RegisterProfile(Player player)
        {
            var result = await _playerService.UpdatePlayer(player);
            _taskCompletionSource.SetResult(result);

            //await DisplayAlert("Successfully Added", $"{name}", "Okay");
        }

        public async Task ChangedClass()
        {

        }

    }
}
