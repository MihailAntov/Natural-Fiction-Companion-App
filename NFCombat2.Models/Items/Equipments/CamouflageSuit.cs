

using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Equipments
{
    public class CamouflageSuit : Equipment, IModifyAction
    {
        public Task Modify(ICombatAction action, Fight fight)
        {
            if(action is EnemyRangedAttack attack)
            {
                attack.IsAccuracyReduced = true;
            }
            return Task.CompletedTask;
        }
    }
}
