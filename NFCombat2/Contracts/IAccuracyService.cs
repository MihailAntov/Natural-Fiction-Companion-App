

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Contracts
{
    public interface IAccuracyService
    {
        public AttackResult Hits(IHaveAttackRoll combatAction, Fight fight);

    }
}
