

using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class SackOfAcorns : Item, IInventoryActiveItem
    {
        public SackOfAcorns()
        {
            Name = "Sack of Acorns";
            IsConsumable = true;
            Quantity = 1;
        }
        

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Pathogens--;
            return new PathogenDecrease(player, 1);
        }
    }
}
