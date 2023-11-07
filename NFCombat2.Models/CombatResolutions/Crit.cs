using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class Crit : ICombatResolution
    {
        private int _numberOfCrits;
        public Crit(int numberOfCrits)
        {
            _numberOfCrits = numberOfCrits;
        }
        public string[] MessageArgs => new string[] { _numberOfCrits.ToString() };
        public MessageType MessageType => MessageType.CritMessage;

        public void Resolve(Fight fight)
        {
            fight.RemainingCrits += _numberOfCrits;
        }
    }
}
