

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;

namespace NFCombat2.ViewModels
{
    public class ConfirmationPopupViewModel : BaseViewModel
    {
        private TaskCompletionSource<bool> _taskCompletionSource;
        public Command ConfirmCommand { get; set; }
        public Command CancelCommand { get; set; }
        public ConfirmationPopupViewModel(string message , TaskCompletionSource<bool> taskCompletionSource, INameService nameService) : base (nameService)
        {
            Message = message;
            UpdateLanguageSpecificProperties();
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

        public override void UpdateLanguageSpecificProperties()
        {
            ConfirmText = _nameService.Label(LabelType.Yes);
            CancelText = _nameService.Label(LabelType.No);
        }
    }
}
