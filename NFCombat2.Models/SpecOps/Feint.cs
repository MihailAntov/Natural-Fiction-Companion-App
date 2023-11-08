using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.SpecOps
{
    public class Feint : Technique, IModifyAction
    {
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
    }
}
