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

        public Task Modify(ICombatResolution resolution)
        {
            if (resolution is EnemyDealDamage dealDamage)
            {
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
            return Task.CompletedTask;
        }
    }
}
