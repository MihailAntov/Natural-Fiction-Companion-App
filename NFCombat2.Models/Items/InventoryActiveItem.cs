

namespace NFCombat2.Models.Items
{
    public abstract class InventoryActiveItem : Item
    {
        public abstract void AffectPlayer(Player.Player player);
    }
}
