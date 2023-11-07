using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Contracts
{
    public interface IPopupService
    {
        void ShowPopup(Popup popup);
        void ShowToast(string text);
        void ShowDiceRollsPopup(IHaveRolls effect);
        void ShowDiceAttackRollPopup(IHaveAttackRoll effect);
    }
}
