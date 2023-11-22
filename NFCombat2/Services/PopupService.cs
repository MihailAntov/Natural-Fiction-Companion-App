using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.PopUps;
using NFCombat2.Contracts;
using NFCombat2.Views;
using NFCombat2.ViewModels;
using NFCombat2.Models.Player;

namespace NFCombat2.Services
{
    public class PopupService : IPopupService
    {
        private IPlayerService _playerService;
        public PopupService(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public async Task<TaskCompletionSource<bool>> ShowDiceAttackRollPopup(IHaveAttackRoll effect)
        {
            var task = new TaskCompletionSource<bool>();
            bool canReroll = _playerService.CurrentPlayer is SpecOps;
            var viewModel = new DiceResultViewModel(effect, task, canReroll);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public async Task<TaskCompletionSource<bool>> ShowMeleeCombatRollsPopup(IHaveOpposedRolls effect)
        {
            var task = new TaskCompletionSource<bool>();
            bool canReroll = _playerService.CurrentPlayer is SpecOps;
            var viewModel = new DiceResultViewModel(effect.AttackerResult, effect.AttackerMessage, task , canReroll);
            var popup = new DiceResultView(viewModel);

            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();

            task = new TaskCompletionSource<bool>();
            viewModel = new DiceResultViewModel(effect.DefenderResult, effect.DefenderMessage, task, canReroll);
            popup = new DiceResultView(viewModel);
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();


            return task;
        }

        public async Task<TaskCompletionSource<bool>> ShowDiceRollsPopup(IHaveRolls effect)
        {
            var task = new TaskCompletionSource<bool>();
            bool canReroll = _playerService.CurrentPlayer is SpecOps;
            var viewModel = new DiceResultViewModel(effect, task, canReroll);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public async Task<TaskCompletionSource<IAddable>> ShowEntryWithSuggestionsPopup(IPlayerService playerService, ICollection<IAddable> options)
        {
            var task = new TaskCompletionSource<IAddable>();
            var viewModel = new EntryWithSuggestionsViewModel(playerService, options, task);
            var popup = new EntryWithSuggestions(viewModel);
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

        public async Task<TaskCompletionSource<Player>> ShowAddProfilePopup()
        {
            TaskCompletionSource<Player> task = new TaskCompletionSource<Player>();
            var viewmodel = new AddingProfileViewModel(_playerService, task);

            var popup = new AddingProfileView(viewmodel);
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }
    }
}
