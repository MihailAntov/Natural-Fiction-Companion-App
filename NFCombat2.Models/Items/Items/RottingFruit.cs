

using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class RottingFruit : Item, IInventoryActiveItem
    {
        public RottingFruit()
        {
            Name = "Rotting Fruit";
            IsConsumable = true;
            Quantity = 1;

        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            //Quantity--;
            //if (Quantity == 0)
            //{
            //    player.Items.Remove(this);
            //    player.ExtraItems.Remove(this);
            //}
            player.Health += 4;
            return new Heal(DiceCalculator.Calculate(0, null, 4));
        }
    }
}
