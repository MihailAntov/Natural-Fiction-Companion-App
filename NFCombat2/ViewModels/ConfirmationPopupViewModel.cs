

namespace NFCombat2.ViewModels
{
    public class ConfirmationPopupViewModel
    {
        private TaskCompletionSource<bool> _taskCompletionSource;
        public Command ConfirmCommand { get; set; }
        public Command CancelCommand { get; set; }
        public ConfirmationPopupViewModel(string message , TaskCompletionSource<bool> taskCompletionSource)
        {
            Message = message;
            ConfirmText = "Yes";
            CancelText = "No";
            _taskCompletionSource = taskCompletionSource;
            ConfirmCommand = new Command(Confirm);
            CancelCommand = new Command(Cancel);

        }

        public string Message { get; set; }
        public string ConfirmText { get; set; }
        public string CancelText { get; set; }

        public void Confirm()
        {
            _taskCompletionSource.SetResult(true);
        }

        public void Cancel()
        {
            _taskCompletionSource?.SetResult(false);
        }
    }
}
