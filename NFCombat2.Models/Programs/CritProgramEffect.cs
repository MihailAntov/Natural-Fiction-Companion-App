

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
        public int Cost { get; set; }
        public MessageType MessageType => MessageType.ProgramCritMessage;
        public string[] MessageArgs =>Array.Empty<string>();
        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            //fight.RemainingCrits += _numberOfCrits;
            var crit = new GuaranteedCrits(_numberOfCrits);
            fight.Player.Overload += Cost;
            fight.Effects.Enqueue(crit);
            return new List<ICombatResolution>() { crit };
        }

        public bool HasEffect(Fight fight)
        {
            return true;
        }
    }
}
