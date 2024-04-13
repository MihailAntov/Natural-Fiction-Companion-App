

using NFCombat2.Models.Actions;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Common.Helpers;
using NFCombat2;
using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Programs
{
    public class DamageProgramEffect : IProgramEffect, ITarget, IHaveRolls, IHaveDelayedRolls
    {

        public DamageProgramEffect(int numberOfDice, int flatDamage, int minRange = 0, int maxRange = 10, bool areaOfEffect = false, int delayedNumberOfDice = 0, int delayedFlatDamage = 0, int delayedDuration = 0)
        {
            _numberOfDice = numberOfDice;
            _flatDamage = flatDamage;
            _delayedNumberOfDice = delayedNumberOfDice;
            _delayedFlatDamage = delayedFlatDamage;
            _delayedDuration = delayedDuration;
            AreaOfEffect = areaOfEffect;
            MinRange = minRange;
            MaxRange = maxRange;
            RollsResult = DiceCalculator.Calculate(numberOfDice, DiceMessage, flatDamage);
        }
        private int _numberOfDice;
        private int _flatDamage;
        private int _delayedNumberOfDice;
        private int _delayedFlatDamage;
        private int _delayedDuration;
        
        public bool AreaOfEffect { get; set; }

        public ICollection<Enemy> Targets { get; set; } = new HashSet<Enemy>();
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public MessageType MessageType => MessageType.ProgramDamageMessage;
        public string[] MessageArgs => Array.Empty<string>();

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage => "Your program's damage";

        public DiceRollResult DelayedRollsResult { get; set; }

        public string DelayedDiceMessage => "Your program's followup damage";

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var damage = new DealDamage(RollsResult, Targets);
            fight.Effects.Enqueue(damage);
                
            if(_delayedDuration > 0)
            {
                DelayedRollsResult = DiceCalculator.Calculate(_delayedNumberOfDice,DelayedDiceMessage, _delayedFlatDamage);
                fight.DelayedEffects.Enqueue(new DealDamage(DelayedRollsResult, Targets));
            }

            return new List<ICombatResolution>() { damage };
        }

        public bool HasEffect(Fight fight)
        {
            return fight.Enemies.Any(e=> e.Distance >= MinRange && e.Distance <= MaxRange);
        }
    }
}
