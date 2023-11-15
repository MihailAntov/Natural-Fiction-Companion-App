using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Contracts
{
    public interface IPopupService
    {
        void ShowPopup(Popup popup);
        void ShowToast(string text);
        Task<TaskCompletionSource<bool>> ShowDiceRollsPopup(IHaveRolls effect);
        Task<TaskCompletionSource<bool>> ShowDiceAttackRollPopup(IHaveAttackRoll effect);
        Task<TaskCompletionSource<bool>> ShowEntryWithSuggestionsPopup(IPlayerService playerService, ICollection<IAddable> effect);
    }
}
