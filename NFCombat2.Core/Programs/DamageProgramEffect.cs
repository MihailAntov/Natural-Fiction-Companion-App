

using NFCombat2.Models.Actions;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.DiceRoller;
using NFCombat2;
using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Programs
{
    public class DamageProgramEffect : IProgramEffect, ITarget
    {
        
        public DamageProgramEffect(int numberOfDice, int flatDamage,Program program, int delayedNumberOfDice = 0, int delayedFlatDamage = 0, int delayedDuration = 0)
        {
            _numberOfDice = numberOfDice;
            _flatDamage = flatDamage;
            _delayedNumberOfDice = delayedNumberOfDice;
            _delayedFlatDamage = delayedFlatDamage;
            _delayedDuration = delayedDuration;
            AreaOfEffect = program.AreaOfEffect;
            MinRange = program.MinRange;
            MaxRange = program.MaxRange;
        }
        private int _numberOfDice;
        private int _flatDamage;
        private int _delayedNumberOfDice;
        private int _delayedFlatDamage;
        private int _delayedDuration;
        
        public bool AreaOfEffect { get; set; }

        public ICollection<Enemy> Targets { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public MessageType MessageType => MessageType.ProgramDamageMessage;
        public string[] MessageArgs => Array.Empty<string>();   
        public ICombatResolution AddToCombatEffects(Fight fight)
        {
            int amount = DiceCalculator.Calculate(_numberOfDice, _flatDamage);

            var damage = new DealDamage(amount, Targets);

                fight.Effects.Enqueue(damage);
                
            if(_delayedDuration > 0)
            {
                int delayedAmount = DiceCalculator.Calculate(_delayedNumberOfDice, _delayedFlatDamage);
                fight.DelayedEffects.Enqueue(new DealDamage(delayedAmount, Targets));
            }

            return damage;
        }

        
    }
}
