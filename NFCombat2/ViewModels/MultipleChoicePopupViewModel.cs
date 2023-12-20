

using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.ViewModels
{
    public class MultipleChoicePopupViewModel
    {
        public List<IOption> Options { get; set; }
        private Fight _fight;
        public Command ChooseCommand { get; set; }
        private TaskCompletionSource<IOption> _taskCompletionSource;
        public Popup Popup { get; set; }
        public MultipleChoicePopupViewModel(List<IOption> options, Fight fight, TaskCompletionSource<IOption> taskCompletionSource)
        {
            Options = options;
            _fight = fight;
            _taskCompletionSource = taskCompletionSource;
            ChooseCommand = new Command<IOption>(Choose);
        }

        public void Choose(IOption option)
        {

            _taskCompletionSource.SetResult(option);
            Popup.CloseAsync();
        }


    }
}
