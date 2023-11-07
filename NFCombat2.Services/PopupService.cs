using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.PopUps;
using NFCombat2.Services.Contracts;


namespace NFCombat2.Services
{
    public class PopupService : IPopupService
    {
        public void ShowDiceAttackRollPopup(IHaveAttackRoll effect)
        {
            var popup = new DiceRollPopup(effect.AttackRollResult);
            ShowPopup(popup);
        }

        public void ShowDiceRollsPopup(IHaveRolls effect)
        {
            var popup = new DiceRollPopup(effect.RollsResult);
            ShowPopup(popup);
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
