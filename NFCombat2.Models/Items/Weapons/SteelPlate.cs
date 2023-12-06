using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Weapons
{
    public class SteelPlate : Weapon, IModifyResolution
    {
        public SteelPlate()
        {
            ItemType = ItemType.SteelPlate;
            Name = "Steel Plate";
        }

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if (resolution is EnemyDealDamage dealDamage)
            {
                //TODO : make the shield persists its durability. Low priority.
                if (Durability >= dealDamage.Damage)
                {
                    Durability -= dealDamage.Damage;
                    dealDamage.Damage = 0;
                }
                else
                {
                    dealDamage.Damage -= Durability;
                    Durability = 0;
                }
            }
            return Task.FromResult(new List<ICombatAction>());
        }
    }
}
