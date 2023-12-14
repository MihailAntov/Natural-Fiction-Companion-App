

using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Items
{
    public class FuelCellBattery : Item, IInventoryActiveItem
    {
        public FuelCellBattery()
        {
            Name = "TODO";
            IsConsumable = true;
            Quantity = 1;
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            player.Fuel += 30;
            return new FuelIncrease(player, 30);
        }
    }
}
