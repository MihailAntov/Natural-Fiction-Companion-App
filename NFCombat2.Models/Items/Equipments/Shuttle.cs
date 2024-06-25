

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class Shuttle : Equipment, IModifyPlayer
    {
        public Shuttle()
        {
            IsInvention = true;
        }

        public void OnAdded(Player.Player player)
        {
            player.HasShuttle = true;
        }

        public void OnRemoved(Player.Player player)
        {
            player.HasShuttle = player.Equipment.Any(e=> e.ItemType == Common.Enums.ItemType.Shuttle);
        }
    }
}
