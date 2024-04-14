using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Programs
{
    public class BonusActionProgramEffect : IProgramEffect
    {
        public MessageType MessageType => MessageType.ProgramBonusActionmessage;
        public string[] MessageArgs => Array.Empty<string>();
        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var bonus = new BonusAction();
            fight.Player.Overload += Cost;
            fight.Effects.Enqueue(bonus);
            return new List<ICombatResolution>() { bonus };

        }
        public int Cost { get; set; }

        public bool HasEffect(Fight fight)
        {
            return true;
        }
    }
}
