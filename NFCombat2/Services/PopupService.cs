using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.PopUps;
using NFCombat2.Contracts;
using NFCombat2.Views;
using NFCombat2.ViewModels;

namespace NFCombat2.Services
{
    public class PopupService : IPopupService
    {
        public async Task<TaskCompletionSource<bool>> ShowDiceAttackRollPopup(IHaveAttackRoll effect)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect, task);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public async Task<TaskCompletionSource<bool>> ShowDiceRollsPopup(IHaveRolls effect)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect, task);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public void ShowPopup(Popup popup)
        {
            Page page = Application.Current?.MainPage ?? throw new NullReferenceException();
            page.ShowPopup(popup);
            
        }

        public void ShowToast(string message)
        {
            IToast toast = Toast.Make(message, ToastDuration.Short);
            toast.Show();
        }


    }
}
