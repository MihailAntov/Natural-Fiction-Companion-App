

using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Weapons
{
    public class EMShield : Weapon, IModifyResolution
    {
        public int Durability { get; set; } = 100;

        public Task Modify(ICombatResolution resolution)
        {
            if(resolution is EnemyDealDamage dealDamage)
            {
                if(Durability >= dealDamage.Damage)
                {
                    Durability-= dealDamage.Damage;
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
