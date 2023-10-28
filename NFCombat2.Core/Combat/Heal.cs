using NFCombat2.Models.Contracts;
using NFCombat2.Models.DiceRoller;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    public class Heal : IAffectCombat
    {
        private int _dice;
        private int _delayedDice;
        public Heal(int dice, int delayedDice)
        {
            _dice = dice;
            _delayedDice = delayedDice;
        }
        public void AffectFight(Fight fight)
        {
            fight.Player.Health += DiceCalculator.Calculate(_dice);
            if(_delayedDice > 0)
            {
                fight.DelayedEffects.Enqueue(new Heal(_delayedDice, 0));
            }
        }
    }
}
