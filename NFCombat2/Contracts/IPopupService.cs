using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
using NFCombat2.Models.Programs;

namespace NFCombat2.Contracts
{
    public interface IPopupService
    {
        void ShowPopup(Popup popup);
        void ShowToast(string text);
        Task<TaskCompletionSource<bool>> ShowDiceRollsPopup(IHaveRolls effect, bool canReroll, int reRollsAvailable);
        Task<TaskCompletionSource<bool>> ShowDiceAttackRollPopup(IHaveAttackRoll effect, bool canReroll, int reRollsAvailable);
        Task<TaskCompletionSource<bool>> ShowMeleeCombatRollsPopup(IHaveOpposedRolls effect, bool canReroll, int reRollsAvailable);
        Task<Program> ShowCastPopup(IPlayerService playerService);
        Task<Player> ShowAddProfilePopup(IPlayerService playerService);
        Task<IAddable> ShowEntryWithSuggestionsPopup(ICollection<IAddable> effect, IPlayerService playerService);
    }
}
