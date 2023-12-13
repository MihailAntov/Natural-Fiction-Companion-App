

namespace NFCombat2.Models.Contracts
{
    public interface IModifyPlayer
    {
        public void OnAdded(Player.Player player);
        public void OnRemoved(Player.Player player);

    }
}
