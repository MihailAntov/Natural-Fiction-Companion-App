using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Programs;
using NFCombat2.Contracts;
using NFCombat2.Views;
using NFCombat2.ViewModels;
using NFCombat2.Models.Player;
using NFCombat2.Common.Enums;
using NFCombat2.Models.SpecOps;

namespace NFCombat2.Services
{
    public class MyPopupService : IMyPopupService
    {
        private readonly IProgramService _programService;
        private readonly INameService _nameService;
        public MyPopupService(IProgramService programService , INameService nameService)
        {
            _programService = programService;
            _nameService = nameService;

        }
        public async Task<TaskCompletionSource<bool>> ShowDiceAttackRollPopup(IHaveAttackRoll effect, Player player, bool hasReroll = false, bool hasFreeReroll = false)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect,player,  task, hasReroll, hasFreeReroll,_nameService);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public async Task<TaskCompletionSource<bool>> ShowMeleeCombatRollsPopup(IHaveOpposedRolls effect, Player player, bool hasReroll, bool hasFreeReroll = false)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect.AttackerResult, effect.AttackerMessage, player, task , hasReroll, hasFreeReroll, _nameService);
            var popup = new DiceResultView(viewModel);

            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();

            task = new TaskCompletionSource<bool>();
            viewModel = new DiceResultViewModel(effect.DefenderResult, effect.DefenderMessage, player, task, hasReroll, hasFreeReroll, _nameService);
            popup = new DiceResultView(viewModel);
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();


            return task;
        }

        public async Task<TaskCompletionSource<bool>> ShowDiceRollsPopup(IHaveRolls effect, Player player, bool hasReroll, bool hasFreeReroll = false)
        {
            var task = new TaskCompletionSource<bool>();
            var viewModel = new DiceResultViewModel(effect, player, task, hasReroll, hasFreeReroll, _nameService);
            var popup = new DiceResultView(viewModel);
            
            ShowPopup(popup);
            await task.Task;
            await popup.CloseAsync();
            return task;
        }

        public async Task<IAddable> ShowEntryWithSuggestionsPopup(ICollection<IAddable> options, IPlayerService playerService)
        {
            var task = new TaskCompletionSource<IAddable>();
            var viewModel = new EntryWithSuggestionsViewModel(playerService, options, task, _nameService);
            var suggestions = new EntryWithSuggestions(viewModel);
            //ShowPopup(suggestions);
            await Shell.Current.Navigation.PushAsync(suggestions);
            var result = await task.Task;
            if(result != null)
            {
                await Shell.Current.Navigation.PopAsync();
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
            var viewmodel = new AddingProfileViewModel(playerService,this, task,_nameService);

            var popup = new AddingProfileView(viewmodel);
            ShowPopup(popup);
            var player = await task.Task;
            if(player != null)
            {
                await popup.CloseAsync();
            }
            return player;
        }

        public async Task<ProgramExecution> ShowCastPopup(IPlayerService playerService)
        {
            TaskCompletionSource<ProgramExecution> taskCompletionSource = new TaskCompletionSource<ProgramExecution>();
            var viewmodel = new ProgramCastViewModel(taskCompletionSource, _programService, playerService, _nameService);
            var popup = new ProgramCastView(viewmodel);
            viewmodel.Popup = popup;
            ShowPopup(popup);
            var execution = await taskCompletionSource.Task;
            if(execution.Result != ProgramExecutionResult.Cancelled)
            {
                await popup.CloseAsync();
            }
            return execution;
        }

        public async Task<Technique> ShowTechniquePopup(List<TechniqueChoice> chocies)
        {
            TaskCompletionSource<Technique> taskCompletionSource = new TaskCompletionSource<Technique>();
            var viewModel = new TechniqueChoiceViewModel(chocies,taskCompletionSource);
            var popup = new TechniqueChoiceView(viewModel);
            ShowPopup(popup);
            var result = await taskCompletionSource.Task;
            if(result != null)
            {
                await popup.CloseAsync();
            }
            return result;
        }

        public async Task<Hand> ShowHandChoicePopup(INameService nameSerivce)
        {
            TaskCompletionSource<Hand> taskCompletionSource=  new TaskCompletionSource<Hand>();
            var viewmodel = new HandChoiceViewModel(taskCompletionSource,nameSerivce);
            var popup = new HandChoiceView(viewmodel);
            viewmodel.Popup = popup;
            ShowPopup(popup);
            var execution = await taskCompletionSource.Task;
            return execution;
        }
    }
}
