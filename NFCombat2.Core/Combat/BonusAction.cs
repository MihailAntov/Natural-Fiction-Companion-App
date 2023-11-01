using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    public class BonusAction : IAffectCombat
    {
        public MessageType MessageType => MessageType.BonusActionMessage;
        public string[] MessageArgs => Array.Empty<string>();
        public void AffectFight(Fight fight)
        {
            fight.HasBonusAction = true;
        }
    }
}
