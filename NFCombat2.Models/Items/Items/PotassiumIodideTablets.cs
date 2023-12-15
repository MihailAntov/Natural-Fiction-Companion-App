
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Items
{
    public class PotassiumIodideTablets : Item, IInventoryActiveItem
    {
        public PotassiumIodideTablets()
        {
            Name = "TODO";
            IsConsumable = true;
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Ionization--;
            return new IonizationDecrease(player, 1);
        }
    }
}
