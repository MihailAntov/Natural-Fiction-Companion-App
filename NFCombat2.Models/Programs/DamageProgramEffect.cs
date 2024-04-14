

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

        public DamageProgramEffect(int numberOfDice, int flatDamage, DiceMessageType messageType)
        {
            NumberOfDice = numberOfDice;
            FlatDamage = flatDamage;
            
            DiceMessageType = messageType;
            RollsResult = DiceCalculator.Calculate(numberOfDice, DiceMessage, flatDamage);
        }
        public int NumberOfDice { get; set; }
        public int FlatDamage { get; set; }
        public int DelayedNumberOfDice { get; set; }
        public int DelayedFlatDamage { get; set; }
        public int DelayedDuration { get; set; }

        public bool AreaOfEffect { get; set; }
        public int Cost { get; set; }
        public ICollection<Enemy> Targets { get; set; } = new HashSet<Enemy>();
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public MessageType MessageType { get; set; }
        public string[] MessageArgs => Array.Empty<string>();

        public DiceRollResult RollsResult { get; set; }

        public DiceMessageType DiceMessageType { get; set; }
        public string DiceMessage { get; set; }
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();

        public DiceRollResult DelayedRollsResult { get; set; }

        public DiceMessageType DelayedDiceMessageType { get; set; }
        public string DelayedDiceMessage { get; set; }

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var damage = new DealDamage(RollsResult, Targets);
            fight.Player.Overload += Cost;
            fight.Effects.Enqueue(damage);
                
            if(DelayedDuration > 0)
            {
                //DelayedRollsResult = DiceCalculator.Calculate(DelayedNumberOfDice,DelayedDiceMessage, DelayedFlatDamage);
                //fight.DelayedEffects.Enqueue(new DealDamage(DelayedRollsResult, Targets));
                var delayedEffect = new DamageProgramEffect(DelayedNumberOfDice, DelayedFlatDamage, DiceMessageType.DelayedProgramDamageRoll)
                {
                    Targets = this.Targets,
                    MinRange = this.MinRange,
                    MaxRange = this.MaxRange
                };
                fight.DelayedEffects.Enqueue(delayedEffect);
            }

            return new List<ICombatResolution>() { damage };
        }

        public bool HasEffect(Fight fight)
        {
            return fight.Enemies.Any(e=> e.Distance >= MinRange && e.Distance <= MaxRange);
        }
    }
}
