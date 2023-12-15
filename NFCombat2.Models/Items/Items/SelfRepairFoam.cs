

using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class SelfRepairFoam : Item, IInventoryActiveItem
    {
        public SelfRepairFoam()
        {
            Name = "Self Repair Foam";
            IsConsumable = true;
        }
        

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Trauma--;
            return new TraumaDecrease(player, 1);
        }
    }
}
