using CommunityToolkit.Maui.Views;
using NFCombat2.Services.Contracts;


namespace NFCombat2.Services
{
    public class PopupService : IPopupService
    {
        public void ShowPopup(Popup popup)
        {
            Page page = Application.Current?.MainPage ?? throw new NullReferenceException();
            page.ShowPopup(popup);
        }
    }
}
