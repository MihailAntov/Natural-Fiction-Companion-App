using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.SpecOps
{
    public class Feint : Technique, IModifyAction
    {
        public void Modify(ICombatAction action)
        {
            if(action is IHaveAttackRoll attack)
            {
                attack.AttackRollResult.DiceValue -= 1;
            };
        }
    }
}
