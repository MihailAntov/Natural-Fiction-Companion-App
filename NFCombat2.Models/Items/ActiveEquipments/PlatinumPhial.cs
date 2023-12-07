

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class PlatinumPhial : Equipment, IInventoryActiveItem
    {
        public PlatinumPhial()
        {
            IsConsumable = true;
            Quantity = 1;
        }
        public ICombatResolution AffectPlayer(Player.Player player)
        {
            Quantity--;
            if(Quantity <= 0)
            {
                player.Equipment.Remove(this);
            }
            player.MaxOverload++;
            return new MaxOverloadIncrease(player);
        }
    }
}
