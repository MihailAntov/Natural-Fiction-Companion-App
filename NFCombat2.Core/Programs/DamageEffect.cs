

using NFCombat2.Models.Actions;
using NFCombat2.Models.Combat;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.DiceRoller;
using NFCombat2;

namespace NFCombat2.Models.Programs
{
    public class DamageEffect : IProgramEffect
    {
        
        public DamageEffect(int numberOfDice, int flatDamage,bool areaOfEffect = false, int delayedNumberOfDice = 0, int delayedFlatDamage = 0, int delayedDuration = 0)
        {
            _numberOfDice = numberOfDice;
            _flatDamage = flatDamage;
            _delayedNumberOfDice = delayedNumberOfDice;
            _delayedFlatDamage = delayedFlatDamage;
            _delayedDuration = delayedDuration;
            _areaOfEffect = areaOfEffect;
        }
        private bool _areaOfEffect { get; set; }
        private int _numberOfDice { get; set; }
        private int _flatDamage { get; set; }
        private int _delayedNumberOfDice { get; set; }
        private int _delayedFlatDamage { get; set; }
        private int _delayedDuration { get; set; }

        public Enemy Target { get; set; }

        public void AffectFight(Fight fight)
        {
            int amount = DiceCalculator.Calculate(_numberOfDice, _flatDamage);
            IList<Enemy> targets = new List<Enemy>();

            if (!_areaOfEffect)
            {
                targets.Add(Target);
            }
            else
            {
                targets = fight.Enemies;
            }

                fight.Effects.Enqueue(new DealDamage(amount, targets));
                
            if(_delayedDuration > 0)
            {
                int delayedAmount = DiceCalculator.Calculate(_delayedNumberOfDice, _delayedFlatDamage);
                fight.DelayedEffects.Enqueue(new DealDamage(delayedAmount, targets));
            }
        }

        
    }
}
