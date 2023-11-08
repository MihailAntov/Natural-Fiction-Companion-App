

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Models.SpecOps;

namespace NFCombat2.Services
{
    public class AccuracyService : IAccuracyService
    {
        public AttackResult Hits(IHaveAttackRoll combatAction, Fight fight)
        {
            var diceResult = combatAction.AttackRollResult.DiceValue;

            

            int hitsAt = 0;
            int critsAt = 0;
            switch(combatAction.Accuracy)
            {
                case Accuracy.S:
                    hitsAt = 2;
                    critsAt = 5;
                    break;
                case Accuracy.A:
                    hitsAt = 2;
                    critsAt = 6;
                    break;
                case Accuracy.B:
                    hitsAt = 3;
                    critsAt = 6;
                    break;
                case Accuracy.C:
                    hitsAt = 3;
                    critsAt = 99;
                    break;
                case Accuracy.D:
                    hitsAt = 4;
                    critsAt = 99;
                    break;
                case Accuracy.E:
                    hitsAt = 5;
                    critsAt = 99;
                    break;
            }

            if(diceResult >= critsAt) { return AttackResult.Crit; }
            if(diceResult >= hitsAt) { return AttackResult.Hit; }
            return AttackResult.Miss;
        }
    }
}
