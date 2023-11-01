

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.DiceRoller;

namespace NFCombat2.Models.Programs
{
    public class HealProgramEffect : IProgramEffect
    {
        private int _dice;
        private int _delayedDice;
        public HealProgramEffect(int dice, int delayedDice)
        {
            _dice = dice;
            _delayedDice = delayedDice;
        }
        public string[] MessageArgs => Array.Empty<string>();
        public MessageType MessageType => MessageType.ProgramHealMessage;

        public ICombatResolution AddToCombatEffects(Fight fight)
        {
            var amount = DiceCalculator.Calculate(_dice);
            var heal = new Heal(amount);
            fight.Effects.Enqueue(heal);
            return heal;
        }

        
    }
}
