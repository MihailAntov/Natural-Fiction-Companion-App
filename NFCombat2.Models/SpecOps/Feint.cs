using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.SpecOps
{
    public class Feint : Technique, IModifyAction
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 25;
        public Task Modify(ICombatAction action, Fight fight)
        {
            //TODO : check with marto if feint works on the same turn or on the next turn
            if(action is EnemyRangedAttack attack && fight.MovedLastTurn)
            {
                if(attack.AttackRollResult.DiceValue > 1)
                {
                    attack.AttackRollResult.DiceValue -= 1;
                }
            };
            return Task.CompletedTask;
        }
        public override TechniqueType Type => TechniqueType.Feint;
    }
}
