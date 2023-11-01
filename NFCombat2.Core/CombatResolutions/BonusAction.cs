using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class BonusAction : ICombatResolution
    {
        public MessageType MessageType => MessageType.BonusActionMessage;
        public string[] MessageArgs => Array.Empty<string>();
        public void Resolve(Fight fight)
        {
            fight.HasBonusAction = true;
        }
    }
}
