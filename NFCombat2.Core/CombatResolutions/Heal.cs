using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.DiceRoller;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class Heal : ICombatResolution
    {
        private int _amount;
        public Heal(int amount)
        {
            _amount = amount;
        }
        public string[] MessageArgs => new string[1] {_amount.ToString()};
        public MessageType MessageType => MessageType.HealMessage;

        public void Resolve(Fight fight)
        {
            //fight.Player.Health += DiceCalculator.Calculate(_dice);

            fight.Player.Health += _amount;
            

        }
    }
}
