using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;

namespace NFCombat2.Services.Contracts
{
    public interface IPopupService
    {
        void ShowPopup(Popup popup);
        void ShowToast(Toast toast);
    }
}
