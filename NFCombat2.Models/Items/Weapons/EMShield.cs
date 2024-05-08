

using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
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
            Weight = 1;
        }
        
        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if(resolution is TakeMeleeDamage takeDamage)
            {

                var pushAway = new List<ICombatAction>() { new EnemyGetPushedAway(takeDamage.Fight, takeDamage.Enemy) };  
                return Task.FromResult(pushAway);
            }
            var result = new List<ICombatAction>();
            return Task.FromResult(result);
            
        }
    }
}
