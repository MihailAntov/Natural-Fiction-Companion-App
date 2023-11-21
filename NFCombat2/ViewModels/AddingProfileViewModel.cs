

using NFCombat2.Contracts;
using System.Xml.Linq;

namespace NFCombat2.ViewModels
{
    public class AddingProfileViewModel
    {
        public Command RegisterCommand { get; set; }
        private readonly IPlayerService _playerService;
        private TaskCompletionSource<bool> _taskCompletionSource;

        public AddingProfileViewModel(IPlayerService playerService, TaskCompletionSource<bool> taskCompletionSource)
        {
            RegisterCommand = new Command<string>(async (name) => await RegisterProfile(name));
            _playerService = playerService;
            _taskCompletionSource = taskCompletionSource;
        }

        public async Task RegisterProfile(string name)
        {

            _taskCompletionSource.SetResult(await _playerService.Save(name));
            //await DisplayAlert("Successfully Added", $"{name}", "Okay");
        }

        public async Task ChangedClass()
        {

        }

    }
}
