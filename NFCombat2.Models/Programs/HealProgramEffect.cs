

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Dice;

namespace NFCombat2.Models.Programs
{
    public class HealProgramEffect : IProgramEffect, IHaveRolls, IHaveDelayedRolls
    {
        private int _dice;
        public int DelayedDice { get; set; }
        public HealProgramEffect(int dice, DiceMessageType messageType)
        {
            _dice = dice;
            RollsResult = DiceCalculator.Calculate(_dice);
            DiceMessageType = messageType;
        }
        public int Cost { get; set; }
        public bool BonusAction { get; set; }
        public string[] MessageArgs => Array.Empty<string>();
        public MessageType MessageType => MessageType.ProgramHealMessage;

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType { get; private set; }
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();
        public DiceRollResult DelayedRollsResult { get; set; }

        public DiceMessageType DelayedDiceMessageType => DiceMessageType.DelayedProgramHealingRoll;

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            //var amount = DiceCalculator.Calculate(_dice);
            var result = new List<ICombatResolution>();
            var heal = new Heal(RollsResult);
            fight.Effects.Enqueue(heal);
            result.Add(heal);
            fight.Player.Overload += Cost;
            if (BonusAction)
            {
                var bonus = new BonusAction();
                fight.Effects.Enqueue(bonus);
                result.Add(bonus);

            }

            
            if (DelayedDice > 0)
            {
                //DelayedRollsResult = DiceCalculator.Calculate(DelayedNumberOfDice,DelayedDiceMessage, DelayedFlatDamage);
                //fight.DelayedEffects.Enqueue(new DealDamage(DelayedRollsResult, Targets));
                var delayedEffect = new HealProgramEffect(DelayedDice, DiceMessageType.DelayedProgramHealingRoll )
                {
                    
                };
                fight.DelayedEffects.Enqueue(delayedEffect);
            }

            RollsResult = DiceCalculator.Calculate(_dice);
            return result;
        }

        public bool HasEffect(Fight fight)
        {
            return true;
        }
    }
}
