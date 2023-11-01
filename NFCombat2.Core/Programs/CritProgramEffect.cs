

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class CritProgramEffect : IProgramEffect
    {
        private int _numberOfCrits;
        public CritProgramEffect(int numberOfCrits)
        {
            _numberOfCrits = numberOfCrits;
        }

        public MessageType MessageType => MessageType.ProgramCritMessage;
        public string[] MessageArgs =>Array.Empty<string>();
        public ICombatResolution AddToCombatEffects(Fight fight)
        {
            //fight.RemainingCrits += _numberOfCrits;
            var crit = new Crit(_numberOfCrits);
            fight.Effects.Enqueue(crit);
            return crit;
        }

        
    }
}
