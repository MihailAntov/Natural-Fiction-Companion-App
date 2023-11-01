

using NFCombat2.Common.Enums;
using NFCombat2.Models.Combat;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class CritEffect : IProgramEffect
    {
        private int _numberOfCrits;
        public CritEffect(int numberOfCrits)
        {
            _numberOfCrits = numberOfCrits;
        }

        public MessageType MessageType => MessageType.ProgramCritMessage;
        public string[] MessageArgs =>Array.Empty<string>();
        public void AffectFight(Fight fight)
        {
            //fight.RemainingCrits += _numberOfCrits;
            fight.Effects.Enqueue(new Crit(_numberOfCrits));
        }

        
    }
}
