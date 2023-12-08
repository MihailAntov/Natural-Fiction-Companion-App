

using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class ChameleonSkin : Equipment, IModifyAction
    {
        public Task Modify(ICombatAction action)
        {
            if (action is EnemyRangedAttack attack)
            {
                attack.IsAccuracyReduced = true;
            }
            return Task.CompletedTask;
        }
    }
}
