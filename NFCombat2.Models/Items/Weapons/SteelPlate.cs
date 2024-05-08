using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
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
            Weight = 1;
        }

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if (resolution is EnemyDealDamage dealDamage)
            {
            int absorbed = 0;
                if (Durability >= dealDamage.Damage)
                {
                    Durability -= dealDamage.Damage;
                    absorbed += dealDamage.Damage;
                    dealDamage.Damage = 0;
                }
                else
                {
                    absorbed += Durability;
                    dealDamage.Damage -= Durability;
                    Durability = 0;
                }
            return Task.FromResult(new List<ICombatAction>() { new SteelPlateAbsorb(absorbed, Durability)});
            }
            return Task.FromResult(new List<ICombatAction>());
        }
    }
}
