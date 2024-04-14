

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
        public bool BonusAction { get; set; }
        public MessageType MessageType => MessageType.ProgramCritMessage;
        public string[] MessageArgs =>Array.Empty<string>();
        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            //fight.RemainingCrits += _numberOfCrits;
            var crit = new GuaranteedCrits(_numberOfCrits);
            List<ICombatResolution> result = new List<ICombatResolution>();
            fight.Player.Overload += Cost;
            fight.Effects.Enqueue(crit);
            result.Add(crit);
            if (BonusAction)
            {
                var bonus = new BonusAction();
                fight.Effects.Enqueue(bonus);
                result.Add(bonus);

            }
            return result;
        }

        public bool HasEffect(Fight fight)
        {
            return true;
        }
    }
}
