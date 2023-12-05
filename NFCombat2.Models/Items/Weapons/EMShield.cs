

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Weapons
{
    public class EMShield : Weapon, IModifyResolution
    {
        public EMShield()
        {
            Name = "Electromagnetic Shield";
            ItemType = ItemType.EMShield;
        }
        
        public Task Modify(ICombatResolution resolution)
        {
           throw new NotImplementedException();
        }
    }
}
