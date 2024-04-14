using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class GuaranteedCrits : ICombatResolution
    {
        private int _numberOfCrits;
        public GuaranteedCrits(int numberOfCrits)
        {
            _numberOfCrits = numberOfCrits;
        }
        public string[] MessageArgs => new string[] { _numberOfCrits.ToString() };
        public MessageType MessageType => MessageType.GuaranteedCritsMessage;

        public async Task Resolve(Fight fight)
        {
            fight.RemainingCrits += _numberOfCrits;
        }
    }
}
