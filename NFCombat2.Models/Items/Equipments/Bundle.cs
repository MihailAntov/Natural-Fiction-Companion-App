

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class Bundle : Equipment, IModifyPlayer
    {
        public Bundle()
        {
            Name = "Bundle";
        }


        public void OnAdded(Player.Player player)
        {
            player.HasExtraBag = true;
        }

        public void OnRemoved(Player.Player player)
        {
            player.HasExtraBag = false;
            player.ExtraItems.Clear();
        }
    }
}
