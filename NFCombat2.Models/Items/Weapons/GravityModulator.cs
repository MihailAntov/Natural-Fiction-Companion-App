using NFCombat2.Common.Enums;

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Weapons
{
    public class GravityModulator : Weapon, IModifyResolution
    {
        public GravityModulator()
        {
            Name = "Gravity Modulator";
            ItemType = ItemType.GravityModulator;
        }
        public Task Modify(ICombatResolution resolution)
        {
            throw new NotImplementedException();
        }
    }
}
