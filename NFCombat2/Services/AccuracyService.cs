

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
        public int Hits(IHaveAttackRoll combatAction, Fight fight, Accuracy accuracy)
        {
            

            if(fight.Player is SpecOps specOps)
            {
                if(specOps.Techniques.Any(s=> s is Feint))
                {
                    if(combatAction.AttackRollResult.DiceValue > 1)
                    {
                        combatAction.AttackRollResult.DiceValue--;
                        //todo check if zero result is possible
                    }
                }
            }

            int hitsAt = 0;
            int critsAt = 0;
            switch(accuracy)
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

            if(combatAction.AttackRollResult.DiceValue >= critsAt) { return 2; }
            if(combatAction.AttackRollResult.DiceValue >= hitsAt) { return 1; }
            return 0;
        }
    }
}
