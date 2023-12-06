using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
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
        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if(resolution is EnemyDealDamage dealDamage)
            {
                dealDamage.Damage -= 3;
            }
            return Task.FromResult(new List<ICombatAction>());
        }
    }
}
