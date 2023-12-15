

using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Items
{
    public class SodiumThiosulfateSerum : Item, IInventoryActiveItem
    {
        public SodiumThiosulfateSerum()
        {
            Name = "TODO";
            IsConsumable = true;
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Pathogens--;
            return new PathogenDecrease(player, 1);
        }
    }
}
