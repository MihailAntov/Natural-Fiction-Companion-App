

using NFCombat2.Models.Combat;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class HealEffect : IProgramEffect
    {
        private int _dice;
        private int _delayedDice;
        public HealEffect(int dice, int delayedDice)
        {
            _dice = dice;
            _delayedDice = delayedDice;
        }
        public void AffectFight(Fight fight)
        {
            fight.Effects.Enqueue(new Heal(_dice, _delayedDice));
        }

        
    }
}
