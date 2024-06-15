using NFCombat2.Models.Player;

namespace NFCombat2.ViewModels
{
    public class ClassPickerPopupViewModel
    {
        private TaskCompletionSource<PlayerClassDisplay> _taskCompletionSource;
        public IList<PlayerClassDisplay> Classes { get; set; }
        public Command ChooseCommand { get; set; }
        public ClassPickerPopupViewModel(TaskCompletionSource<PlayerClassDisplay> taskCompletionSource, IList<PlayerClassDisplay> classes)
        {
            _taskCompletionSource = taskCompletionSource;
            Classes = classes;
            ChooseCommand = new Command<PlayerClassDisplay>(Choose);
        }

        public void Choose(PlayerClassDisplay classDisplay)
        {
            _taskCompletionSource.TrySetResult(classDisplay);
        }

        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(null);
        }
    }
}
