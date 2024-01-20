using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Programs;
using NFCombat2.Models.PopUps;
using NFCombat2.Contracts;
using NFCombat2.Views;
using NFCombat2.ViewModels;
using NFCombat2.Models.Player;

namespace NFCombat2.Services
{
    public class PopupService : IPopupService
    {
        public PopupService()
        {

        }
        public async Task<TaskCompletionSource<bool>> ShowDiceAttackRollPopup(IHaveAttackRoll effect, bool canReroll, int reRollsAvailable)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect, task, canReroll, reRollsAvailable);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public async Task<TaskCompletionSource<bool>> ShowMeleeCombatRollsPopup(IHaveOpposedRolls effect, bool canReroll, int reRollsAvailable)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect.AttackerResult, effect.AttackerMessage, task , canReroll, reRollsAvailable);
            var popup = new DiceResultView(viewModel);

            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();

            task = new TaskCompletionSource<bool>();
            viewModel = new DiceResultViewModel(effect.DefenderResult, effect.DefenderMessage, task, canReroll, reRollsAvailable);
            popup = new DiceResultView(viewModel);
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();


            return task;
        }

        public async Task<TaskCompletionSource<bool>> ShowDiceRollsPopup(IHaveRolls effect, bool canReroll, int reRollsAvailable)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect, task, canReroll, reRollsAvailable);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public async Task<IAddable> ShowEntryWithSuggestionsPopup(IPlayerService playerService, ICollection<IAddable> options)
        {
            var task = new TaskCompletionSource<IAddable>();
            var viewModel = new EntryWithSuggestionsViewModel(playerService, options, task);
            var popup = new EntryWithSuggestions(viewModel);
            ShowPopup(popup);
            var result = await task.Task;
            if(result != null)
            {
                await popup.CloseAsync();
            }
            return result;
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

        public async Task<Player> ShowAddProfilePopup(IPlayerService playerService)
        {
            TaskCompletionSource<Player> task = new TaskCompletionSource<Player>();
            var viewmodel = new AddingProfileViewModel(playerService, task);

            var popup = new AddingProfileView(viewmodel);
            ShowPopup(popup);
            var player = await task.Task;
            if(player != null)
            {
                await popup.CloseAsync();
            }
            return player;
        }

        public async Task<Program> ShowCastPopup()
        {
            TaskCompletionSource<Program> taskCompletionSource = new TaskCompletionSource<Program>();
            var viewmodel = new ProgramCastViewModel(taskCompletionSource);

            var popup = new ProgramCastView(viewmodel);
            ShowPopup(popup);
            var player = await taskCompletionSource.Task;
            if (player != null)
            {
                await popup.CloseAsync();
            }
            return player;
        }
    }
}
