

using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.SpecOps
{
    public class Anticipation : Technique, IModifyAction
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 25;
        public override TechniqueType Type => TechniqueType.Anticipation;

        public Task Modify(ICombatAction action, Fight fight)
        {
            if(action is PlayerRangedAttack attack && !fight.MovedLastTurn && fight.EnemyMovedLastTurn)
            {
                if(attack.Accuracy > Accuracy.S)
                {
                    attack.Accuracy--;
                }
            }
            return Task.CompletedTask;
        }
    }
}
