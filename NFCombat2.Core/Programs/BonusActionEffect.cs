using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Combat;
using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Programs
{
    public class BonusActionEffect : IProgramEffect
    {
        public MessageType MessageType => MessageType.ProgramBonusActionmessage;

        public void AffectFight(Fight fight)
        {
            fight.Effects.Enqueue(new BonusAction());
        }

        
    }
}
