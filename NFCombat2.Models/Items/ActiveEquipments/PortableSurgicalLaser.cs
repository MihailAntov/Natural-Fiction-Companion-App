

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class PortableSurgicalLaser : Equipment, IInventoryActiveItem
    {
        public PortableSurgicalLaser()
        {
            IsConsumable = true;
            Quantity = 1;
            IsInvention = true;
        }

        public ICombatResolution AffectPlayer(Player.Player player)
        {
            throw new NotImplementedException();
        }
    }
}
