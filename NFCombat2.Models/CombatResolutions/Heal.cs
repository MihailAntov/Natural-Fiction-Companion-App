using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class Heal : ICombatResolution
    {
        private DiceRollResult _roll;
        public Heal(DiceRollResult roll)
        {
            _roll = roll;
        }
        public string[] MessageArgs => new string[1] {Amount.ToString()};
        public int Amount => _roll.FlatAmount + _roll.Dice.Select(d=>d.DiceValue).Sum();
        public MessageType MessageType => MessageType.HealMessage;

        public async Task Resolve(Fight fight)
        {
            //fight.Player.Health += DiceCalculator.Calculate(_dice);

            fight.Player.Health += Amount;
            

        }
    }
}
