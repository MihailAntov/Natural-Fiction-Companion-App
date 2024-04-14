

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Common.Helpers;

namespace NFCombat2.Models.Programs
{
    public class HealProgramEffect : IProgramEffect, IHaveRolls
    {
        private int _dice;
        private int _delayedDice;
        public HealProgramEffect(int dice, int delayedDice)
        {
            _dice = dice;
            _delayedDice = delayedDice;
            RollsResult = DiceCalculator.Calculate(_dice);
        }
        public int Cost { get; set; }
        public bool BonusAction { get; set; }
        public string[] MessageArgs => Array.Empty<string>();
        public MessageType MessageType => MessageType.ProgramHealMessage;

        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.ProgramHealingRoll;
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();
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
            return result;
        }

        public bool HasEffect(Fight fight)
        {
            return true;
        }
    }
}
