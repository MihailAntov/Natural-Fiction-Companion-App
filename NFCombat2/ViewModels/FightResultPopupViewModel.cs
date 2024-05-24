
using NFCombat2.Models.Fights;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;

namespace NFCombat2.ViewModels
{
    public class FightResultPopupViewModel : BaseViewModel
    {
        
        private readonly TaskCompletionSource<bool> _taskCompletionSource;
        
        public FightResultPopupViewModel(Fight fight, INameService nameService, TaskCompletionSource<bool> taskCompletionSource) : base (nameService)
        {
            Fight = fight;
            _taskCompletionSource = taskCompletionSource;
            AcceptResultCommand = new Command(AcceptResult);
            RejectResultCommand = new Command(RejectResult);
            Message = _nameService.FightResultMessage(Fight);
            InfoMessage = _nameService.InfoMessage(Fight);
            UpdateLanguageSpecificProperties();
        }
        public Fight Fight { get; set; }
        public string Message { get; set; }
        public string InfoMessage { get; set; }
        public Command AcceptResultCommand { get; set; }
        public Command RejectResultCommand { get; set; }
        public string AcceptButtonName { get; set; }
        public string RejectButtonName { get; set; }

        public override void UpdateLanguageSpecificProperties()
        {
            AcceptButtonName = _nameService.Label(LabelType.AcceptCombatResult);
            RejectButtonName = _nameService.Label(LabelType.RejectCombatResult);
        }

        private void AcceptResult()
        {
            _taskCompletionSource.TrySetResult(true);
        }

        private void RejectResult()
        {
            _taskCompletionSource.TrySetResult(false);
        }
    }
}
