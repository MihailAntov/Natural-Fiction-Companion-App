using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.SpecOps
{
    public class Feint : Technique, IModifyAction
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 25;
        public Task Modify(ICombatAction action)
        {
            if(action is IHaveAttackRoll attack)
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
