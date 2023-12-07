

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class PortableSurgicalLaser : ActiveEquipment
    {
        public PortableSurgicalLaser()
        {
            IsConsumable = true;
            Quantity = 1;
        }
        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
