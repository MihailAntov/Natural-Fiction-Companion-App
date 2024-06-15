using NFCombat2.Models.Player;

namespace NFCombat2.ViewModels
{
    public class ProfilePickerPopupViewModel
    {
        private TaskCompletionSource<Player> _taskCompletionSource;
        public IList<Player> Profiles { get; set; }
        public Command ChooseCommand { get; set; }
        public ProfilePickerPopupViewModel(TaskCompletionSource<Player> taskCompletionSource, IList<Player> profiles)
        {
            _taskCompletionSource = taskCompletionSource;
            Profiles = profiles;
            ChooseCommand = new Command<Player>(Choose);
        }

        public void Choose(Player player)
        {
            _taskCompletionSource.TrySetResult(player);
        }
        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(null);
        }

    }
}
